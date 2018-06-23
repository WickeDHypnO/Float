using System.Collections;
using System.Collections.Generic;
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
	public float distanceMultiplier = 0.5f;
	bool counting = false;
	public ObstacleSpawner spawner;
	public List<Color> colors;
	public GameObject credit;

	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
		try {
			DataManager.LoadData ();
		} catch {
			DataManager.SaveData ();
		}
	}
	public static void SpawnDeathParticles (Vector3 position) {
		Instantiate (instance.destroyParticles, position, Quaternion.identity);
	}

	public void EndGame () {
		counting = false;
		spawner.gameObject.SetActive (false);
		endGameCanvas.SetActive (true);
	}

	public void Restart () {
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

	private void Update () {
		if (counting) {
			distance += Time.deltaTime * distanceMultiplier;
		}
	}
}