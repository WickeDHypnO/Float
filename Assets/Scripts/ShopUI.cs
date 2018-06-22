using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour {

	public GameObject shipShopUI;
	public RectTransform scrollContent;
	public float spacing;
	public List<ShopShipUI> shipUIs;

	void Start () {
		int iterator = 0;
		foreach (ShipDefinition ship in GameManager.instance.ships) {
			var ui = Instantiate (shipShopUI, scrollContent).GetComponent<ShopShipUI> ();
			shipUIs.Add (ui);
			ui.checkmark.SetActive (false);
			ui.shipIcon.sprite = ship.shipIcon;
			ui.name.text = ship.shipName;
			ui.price.text = ship.shipPrice.ToString ("N0") + " Cr";
			ui.ship = ship;
			ui.GetComponent<RectTransform> ().localPosition = new Vector3 (0, -175 + (-iterator * spacing), 0);
			iterator++;
		}
		scrollContent.sizeDelta = new Vector2 (scrollContent.sizeDelta.x, iterator * spacing + 25);
		scrollContent.localPosition = new Vector2 (0, -scrollContent.sizeDelta.y / 2);
		RebuildUI ();
	}

	public void UseShip () {
		foreach (ShopShipUI ship in shipUIs) {
			ship.ship.isUsed = false;
			if (GameManager.instance.ships[GameManager.instance.currentShip] == ship.ship) {
				ship.ship.isUsed = true;
			}
		}
		RebuildUI ();
		DataManager.SaveData ();
	}

	public void BuyShip (ShipDefinition ship) {
		if (GameManager.instance.credits >= ship.shipPrice) {
			GameManager.instance.credits -= ship.shipPrice;
			GameManager.instance.currentShip = GameManager.instance.ships.IndexOf (ship);
			ship.isBought = true;
			FindObjectOfType<MenuUIController>().creditsText.text = GameManager.instance.credits.ToString ("N0");
			UseShip ();
		}
		DataManager.SaveData ();
	}

	public void RebuildUI () {
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
}