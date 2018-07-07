using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnlocksManager : MonoBehaviour {

	public List<float> distances;
	public List<GameObject> obstacles;
	public List<Sprite> obstacleImages;
	public ObstacleSpawner spawner;
	public TextMeshProUGUI distanceText;
	public Image unlockImage;
	public TextMeshProUGUI totalDistanceNumber;
	public GameObject unlocksMain;
	int lastIterator;

	public bool CheckUnlocks () {
		int iterator = 0;
		for (int i = 0; i < distances.Count; i++) {
			if (distances[i] <= GameManager.instance.totalDistance) {
				spawner.obstacles.Add (obstacles[i]);
			} else {
				iterator = i;
				break;
			}
		}
		distanceText.text = distances[iterator].ToString ("N0") + " m";
		unlockImage.sprite = obstacleImages[iterator];
		totalDistanceNumber.text = GameManager.instance.totalDistance.ToString ("N0") + " m";
		if (iterator == 0) {
			unlocksMain.SetActive (false);
		}
		if(lastIterator != iterator && lastIterator != 0)
		{
			lastIterator = iterator;
			return true;
		}
		else
		{
			return false;
		}
	}
}