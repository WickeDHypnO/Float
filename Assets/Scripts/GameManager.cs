using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public GameObject destroyParticles;
	public GameObject endGameCanvas;
	public List<ShipDefinition> ships;
	public List<TrailDefinition> trails;
	public int currentShip = 0;
	public int currentTrail;
	public List<GameObject> enableObjectsAtGameStart;
	public List<GameObject> objectsToEnableAtRestart;
	public GameObject menu;
	public float distance;
	public float totalDistance;
	public float credits;
	public float recordDistance;
	public float distanceMultiplier = 0.5f;
	bool counting = false;
	public ObstacleSpawner spawner;
	public List<Color> colors;
	public GameObject credit;
	public GameObject newRecordText;
	public GameObject unlockedText;
	public GameObject distanceTextInGame;
	int lastDistance;

	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);

		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ()
			.RequestIdToken ()
			.Build ();

		PlayGamesPlatform.InitializeInstance (config);
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate ();
		StartCoroutine (LogInWithDelay (0.35f));
		try {
			DataManager.LoadData ();
		} catch {
			DataManager.SaveData ();
		}
		try {
			DataManager.LoadDistanceAndCredits ();
		} catch {
			DataManager.SaveDistanceAndCredits ();
		}
		FindObjectOfType<UnlocksManager> ().CheckUnlocks ();
	}
	public static void SpawnDeathParticles (Vector3 position) {
		Instantiate (instance.destroyParticles, position, Quaternion.identity);
	}

	IEnumerator LogInWithDelay (float delay) {
		yield return new WaitForSeconds (delay);
		PlayGamesPlatform.Instance.Authenticate (FindObjectOfType<MenuUIController> ().LoggedUser);
	}

	public void EndGame () {
		counting = false;
		spawner.gameObject.SetActive (false);
		if (distance > recordDistance) {
			recordDistance = distance;
			newRecordText.SetActive (true);
		} else {
			newRecordText.SetActive (false);
		}
		endGameCanvas.SetActive (true);
		totalDistance += distance;
		DataManager.SaveDistanceAndCredits ();
		if (FindObjectOfType<UnlocksManager> ().CheckUnlocks ()) {
			unlockedText.SetActive (true);
		} else {
			unlockedText.SetActive (false);
		}
	}

	public void Restart () {
		lastDistance = 0;
		endGameCanvas.GetComponent<EndGameMenu> ().lastCredits = instance.credits;
		spawner.RestartSpawner ();
		distance = 0;
		endGameCanvas.SetActive (false);
		foreach (ObstacleLogic ol in FindObjectsOfType<ObstacleLogic> ()) {
			Destroy (ol.gameObject);
		}
		foreach (GameObject go in objectsToEnableAtRestart) {
			go.SetActive (true);
		}
		counting = true;
	}

	public void StartGame () {
		endGameCanvas.GetComponent<EndGameMenu> ().lastCredits = instance.credits;
		distance = 0;
		counting = true;
		foreach (GameObject go in enableObjectsAtGameStart) {
			go.SetActive (true);
		}
	}

	public void GoBackToMenu () {
		menu.SetActive (true);
		endGameCanvas.SetActive (false);
		foreach (GameObject go in enableObjectsAtGameStart) {
			go.SetActive (false);
		}
	}

	public void ShowDistanceText (int distanceToShow) {
		distanceTextInGame.GetComponentInChildren<TextMeshProUGUI> ().text = distanceToShow.ToString () + " m";
		distanceTextInGame.SetActive (true);
	}

	private void Update () {
		if (counting) {
			distance += Time.deltaTime * distanceMultiplier;
		}
		if (lastDistance + 50 <= distance) {
			lastDistance += 50;
			ShowDistanceText (lastDistance);
		}
	}
}