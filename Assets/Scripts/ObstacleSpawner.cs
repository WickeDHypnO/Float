using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	public List<GameObject> obstacles;
	public float delay;
	float timer = 0f;
	public Vector3 spawnPoint;
	float defaultDelay;
	public float minDelay;
	public float delayReductionMultiplier;
	public float creditChance = 10f;

	private void Start () {
		defaultDelay = delay;
	}
	void Update () {
		timer += Time.deltaTime;
		if (delay > minDelay) {

			delay -= Time.deltaTime * delayReductionMultiplier;
		} else {
			delay = minDelay;
		}
		if (timer >= delay) {
			timer = 0;
			int rand = Random.Range (0, obstacles.Count);
			var go = Instantiate (obstacles[rand], spawnPoint, obstacles[rand].transform.rotation);
			float random = Random.Range(0, 100f);
			if(random < creditChance)
			{
				go.GetComponent<SpawnCredit>().Spawn();
			}
		}
	}

	public void RestartSpawner () {
		delay = defaultDelay;
	}
}