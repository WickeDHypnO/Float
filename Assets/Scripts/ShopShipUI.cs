using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopShipUI : MonoBehaviour {

	public Image shipIcon;
	public GameObject checkmark;
	public TextMeshProUGUI price;
	public TextMeshProUGUI name;
	public GameObject buyButton;
	public GameObject useButton;
	public ShipDefinition ship;

	public void Choose()
	{
		GameManager.instance.currentShip = GameManager.instance.ships.IndexOf (ship);
		GetComponentInParent<ShopUI>().UseShip();
	}

	public void Buy()
	{
		GetComponentInParent<ShopUI>().BuyShip(ship);
	}
}
