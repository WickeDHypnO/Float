using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class EndGameMenu : MonoBehaviour {

	public TextMeshProUGUI distanceText;
	public TextMeshProUGUI creditsText;
	public TextMeshProUGUI recordText;
	float defaultAmount = 0;
	public float lastCredits = 0;

	private void OnEnable () {
		defaultAmount = 0;
		DOTween.To (() => defaultAmount, x => defaultAmount = x, GameManager.instance.distance, 0.5f).OnUpdate (() => distanceText.text = defaultAmount.ToString ("N0")).OnComplete (PunchScaleDistance);
		DOTween.To (() => lastCredits, x => lastCredits = x, GameManager.instance.credits, 0.5f).OnUpdate (() => creditsText.text = lastCredits.ToString ("N0")).OnComplete (PunchScaleCredits);
		recordText.text = "Record: " + GameManager.instance.recordDistance.ToString ("N0");
	}

	void PunchScaleDistance () {
		distanceText.transform.DOPunchScale (new Vector3 (0.5f, 0.5f, 0), 0.2f);
	}

	void PunchScaleCredits () {
		creditsText.transform.DOPunchScale (new Vector3 (0.5f, 0.5f, 0), 0.2f);
	}
}