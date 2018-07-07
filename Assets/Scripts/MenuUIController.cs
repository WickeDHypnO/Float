using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using GooglePlayGames;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class MenuUIController : MonoBehaviour {

	public GameObject shop;
	public GameObject leaderboards;
	float defaultShopPosition, defaultLeaderboardsPosition;
	public float transitionSpeed = 0.4f;
	public TextMeshProUGUI creditsText;
	public TextMeshProUGUI loggingText;
	public Button leadeboardsButton;

	private void Start () {
	}
	private void OnEnable () {
		defaultShopPosition = shop.transform.localPosition.x;
		defaultLeaderboardsPosition = leaderboards.transform.localPosition.x;
		creditsText.text = GameManager.instance.credits.ToString ("N0");
	}
	public void ShowShop () {
		shop.GetComponent<SortingGroup> ().sortingOrder = 1;
		shop.transform.DOLocalMoveX (0, transitionSpeed);
	}

	public void HideShop () {
		shop.GetComponent<SortingGroup> ().sortingOrder = 0;
		shop.transform.DOLocalMoveX (defaultShopPosition, transitionSpeed);
	}

	public void ShowLeaderboards () {
		leaderboards.GetComponent<SortingGroup> ().sortingOrder = 1;
		leaderboards.transform.DOLocalMoveX (0, transitionSpeed).OnComplete (ShowPlatformLeaderboards);
	}

	public void HideLeaderboards () {
		leaderboards.GetComponent<SortingGroup> ().sortingOrder = 0;
		leaderboards.transform.DOLocalMoveX (defaultLeaderboardsPosition, transitionSpeed);
	}

	public void LoggedUser (bool success) {
		if (success) {
			loggingText.text = "";
			leadeboardsButton.interactable = true;
		} else
			loggingText.text = "Failed to log in";
	}

	void ShowPlatformLeaderboards () {
#if UNITY_ANDROID
		ShowGoogleLeaderboards ();
#elif UNITY_IOS
		ShowIosLeaderboards ();
#else
		ShowGoogleLeaderboards ();
#endif
	}

	void ShowGoogleLeaderboards () {
		if (Social.localUser.authenticated) {
			PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkImf7i1qcfEAIQAA");
		}
	}
	void ShowIosLeaderboards () {

	}

	private void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
}