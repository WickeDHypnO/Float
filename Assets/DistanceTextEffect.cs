using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DistanceTextEffect : MonoBehaviour {

	private void OnEnable () {
		transform.DOScale (new Vector3 (0.5f, 0.5f, 1), 0.2f).SetEase (Ease.Linear).OnComplete (() =>
			transform.DOScale (Vector3.one, 0.3f).SetLoops (5, LoopType.Yoyo).OnComplete (() => transform.DOScale (Vector3.zero, 0.4f).OnComplete(() => transform.parent.gameObject.SetActive (false)))
		);
	}
}