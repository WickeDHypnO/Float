using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ShopUI : MonoBehaviour {

	public GameObject shipShopUI;
	public GameObject trailShopUI;
	public RectTransform shipScrollContent;
	public RectTransform trailsScrollContent;
	public float spacing;
	public List<ShopShipUI> shipUIs;
	public List<TrailShopUI> trailUIs;
	public GameObject shipShop;
	public GameObject trailsShop;
	public bool isShipShopActive;
	public TextMeshProUGUI changeShopButtonText;

	void Start () {
		int iterator = 0;
		foreach (ShipDefinition ship in GameManager.instance.ships) {
			var ui = Instantiate (shipShopUI, shipScrollContent).GetComponent<ShopShipUI> ();
			shipUIs.Add (ui);
			ui.checkmark.SetActive (false);
			ui.shipIcon.sprite = ship.shipIcon;
			ui.name.text = ship.shipName;
			ui.price.text = ship.shipPrice.ToString ("N0") + " Cr";
			ui.ship = ship;
			ui.GetComponent<RectTransform> ().localPosition = new Vector3 (0, -175 + (-iterator * spacing), 0);
			iterator++;
		}
		shipScrollContent.sizeDelta = new Vector2 (shipScrollContent.sizeDelta.x, iterator * spacing + 25);
		shipScrollContent.localPosition = new Vector2 (0, -shipScrollContent.sizeDelta.y / 2);
		iterator = 0;
		foreach (TrailDefinition trail in GameManager.instance.trails) {
			var ui = Instantiate (trailShopUI, trailsScrollContent).GetComponent<TrailShopUI> ();
			trailUIs.Add (ui);
			ui.checkmark.SetActive (false);
			ui.trailIcon.sprite = trail.trailIcon;
			ui.name.text = trail.trailName;
			ui.price.text = trail.trailPrice.ToString ("N0") + " Cr";
			ui.trail = trail;
			ui.GetComponent<RectTransform> ().localPosition = new Vector3 (0, -175 + (-iterator * spacing), 0);
			iterator++;
		}
		trailsScrollContent.sizeDelta = new Vector2 (trailsScrollContent.sizeDelta.x, iterator * spacing + 25);
		trailsScrollContent.localPosition = new Vector2 (0, -trailsScrollContent.sizeDelta.y / 2);
		RebuildShipUI ();
		RebuildTrailUI ();
	}

	public void UseShip () {
		foreach (ShopShipUI ship in shipUIs) {
			ship.ship.isUsed = false;
			if (GameManager.instance.ships[GameManager.instance.currentShip] == ship.ship) {
				ship.ship.isUsed = true;
			}
		}
		RebuildShipUI ();
		DataManager.SaveData ();
	}

	public void BuyShip (ShipDefinition ship) {
		if (GameManager.instance.credits >= ship.shipPrice) {
			GameManager.instance.credits -= ship.shipPrice;
			GameManager.instance.currentShip = GameManager.instance.ships.IndexOf (ship);
			ship.isBought = true;
			FindObjectOfType<MenuUIController> ().creditsText.text = GameManager.instance.credits.ToString ("N0");
			UseShip ();
		}
		DataManager.SaveData ();
	}

	public void RebuildShipUI () {
		foreach (ShopShipUI ship in shipUIs) {
			ship.buyButton.SetActive (true);
			ship.useButton.SetActive (false);
			ship.checkmark.SetActive (false);
			if (ship.ship.isBought) {
				ship.buyButton.SetActive (false);
				ship.useButton.SetActive (true);
			}
			if (ship.ship.isUsed) {
				ship.checkmark.SetActive (true);
				ship.useButton.SetActive (false);
			}
		}
	}

	public void UseTrail () {
		foreach (TrailShopUI trail in trailUIs) {
			trail.trail.isUsed = false;
			if (GameManager.instance.trails[GameManager.instance.currentTrail] == trail.trail) {
				trail.trail.isUsed = true;
			}
		}
		RebuildTrailUI ();
		DataManager.SaveData ();
	}

	public void BuyTrail (TrailDefinition trail) {
		if (GameManager.instance.credits >= trail.trailPrice) {
			GameManager.instance.credits -= trail.trailPrice;
			GameManager.instance.currentTrail = GameManager.instance.trails.IndexOf (trail);
			trail.isBought = true;
			FindObjectOfType<MenuUIController> ().creditsText.text = GameManager.instance.credits.ToString ("N0");
			UseTrail ();
		}
		DataManager.SaveData ();
	}

	public void RebuildTrailUI () {
		foreach (TrailShopUI trail in trailUIs) {
			trail.buyButton.SetActive (true);
			trail.useButton.SetActive (false);
			trail.checkmark.SetActive (false);
			if (trail.trail.isBought) {
				trail.buyButton.SetActive (false);
				trail.useButton.SetActive (true);
			}
			if (trail.trail.isUsed) {
				trail.checkmark.SetActive (true);
				trail.useButton.SetActive (false);
			}
		}
	}

	public void ChangeShop () {
		if (isShipShopActive) {
			trailsShop.GetComponent<RectTransform> ().DOLocalMove (new Vector3 (0, 195, 0), 0.2f);
			shipShop.GetComponent<RectTransform> ().DOLocalMove (new Vector3 (-1080, 195, 0), 0.2f);
			changeShopButtonText.text = "Ships";
		} else {
			shipShop.GetComponent<RectTransform> ().DOLocalMove (new Vector3 (0, 195, 0), 0.2f);
			trailsShop.GetComponent<RectTransform> ().DOLocalMove (new Vector3 (-1080, 195, 0), 0.2f);
			changeShopButtonText.text = "Trails";
		}
		isShipShopActive = !isShipShopActive;
	}
}