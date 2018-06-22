using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
public class ChangeColor : MonoBehaviour {

	public float delay = 4f;
	Material mat;
	public int lastColor;
	void Start () {
		mat = GetComponent<MeshRenderer> ().material;
		ChangeMaterialColor ();
	}

	void ChangeMaterialColor () {
		int rand = Random.Range (0, GameManager.instance.colors.Count);
		while (rand == lastColor) {
			rand = Random.Range (0, GameManager.instance.colors.Count);
		}
		mat.DOColor (GameManager.instance.colors[rand], "_Color", delay).OnComplete(ChangeMaterialColor);
		lastColor = rand;
	}
}