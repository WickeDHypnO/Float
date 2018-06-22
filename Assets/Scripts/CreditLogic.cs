using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditLogic : MonoBehaviour {

	public GameObject collectionParticles;
	private void OnCollisionEnter(Collision other) {
		GameManager.instance.credits += 1;
		Instantiate(collectionParticles, transform.position, collectionParticles.transform.rotation);
		Destroy(gameObject);
	}
}
