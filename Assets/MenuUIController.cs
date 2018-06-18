using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
public class MenuUIController : MonoBehaviour {

	public GameObject shop;
	public GameObject leaderboards;
	float defaultShopPosition, defaultLeaderboardsPosition;
	public float transitionSpeed = 0.4f;
	public TextMeshProUGUI creditsText;
	private void OnEnable () {
		defaultShopPosition = shop.transform.localPosition.x;
		defaultLeaderboardsPosition = leaderboards.transform.localPosition.x;
		creditsText.text = GameManager.instance.credits.ToString("N0");
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
		leaderboards.transform.DOLocalMoveX (0, transitionSpeed);
	}

	public void HideLeaderboards () {
		leaderboards.GetComponent<SortingGroup> ().sortingOrder = 0;
		leaderboards.transform.DOLocalMoveX (defaultLeaderboardsPosition, transitionSpeed);
	}

	private void Update() {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}