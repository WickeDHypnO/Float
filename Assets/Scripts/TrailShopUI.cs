using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrailShopUI : MonoBehaviour {
	public Image trailIcon;
	public GameObject checkmark;
	public TextMeshProUGUI price;
	public TextMeshProUGUI name;
	public GameObject buyButton;
	public GameObject useButton;
	public TrailDefinition trail;

	public void Choose () {
		GameManager.instance.currentTrail = GameManager.instance.trails.IndexOf (trail);
		GetComponentInParent<ShopUI> ().UseTrail ();
	}

	public void Buy () {
		GetComponentInParent<ShopUI> ().BuyTrail (trail);
	}
}