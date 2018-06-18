using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipModel : MonoBehaviour {
	public GameObject model;
	void Start () {
		if (model)
			Destroy (model);
		Instantiate(GameManager.instance.ships[GameManager.instance.currentShip], transform);
	}
}