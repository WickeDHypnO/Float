using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleLogic : MonoBehaviour {

	public float speed;

	private void Start () {
		Destroy (gameObject, 10);
	}
	void FixedUpdate () {
		transform.position -= Vector3.forward * speed;
	}

	private void OnCollisionEnter (Collision other) {
		Debug.Log (other.gameObject.name);
		other.gameObject.SetActive(false);
		GameManager.SpawnDeathParticles(other.transform.position);
		GameManager.instance.EndGame();
	}
}