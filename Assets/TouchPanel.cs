using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPanel : MonoBehaviour {
	public GameObject tutorial;
	private void OnEnable () {
		tutorial.SetActive (true);
	}
}