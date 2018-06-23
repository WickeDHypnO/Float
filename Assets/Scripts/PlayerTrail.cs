using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrail : MonoBehaviour {

	public LineRenderer trail;

	void OnEnable () {
		trail.material = GameManager.instance.trails[GameManager.instance.currentTrail].trailMaterial;
		trail.colorGradient = GameManager.instance.trails[GameManager.instance.currentTrail].trailColor;
	}
}