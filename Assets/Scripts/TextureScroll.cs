using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroll : MonoBehaviour {

	public float speed = 1f;
	Material mat;
	void Start () {
		mat = GetComponent<MeshRenderer> ().material;
	}

	void Update () {
		mat.mainTextureOffset += new Vector2 (0, speed * Time.deltaTime);
		if (mat.mainTextureOffset.x >= 10000f) {
			mat.mainTextureOffset -= new Vector2 (0, 10000f);
		}
	}
}