using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
public class ScalingTextEffect : MonoBehaviour {
	public float scalePunchSize;
	void Start () {
		ScaleUp ();
	}

	void ScaleUp () {
		transform.DOScale (new Vector3 (1 + scalePunchSize, 1 + scalePunchSize, 1), 0.4f).OnComplete (ScaleDown).SetEase (Ease.Linear);
	}

	void ScaleDown () {
		transform.DOScale (Vector3.one, 0.4f).OnComplete (ScaleUp).SetEase (Ease.Linear);
	}
}