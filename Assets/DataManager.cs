using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

	public static void SaveData () {
		string isBoughtData = "";
		string isUsed = "";
		foreach (ShipDefinition ship in GameManager.instance.ships) {
			isBoughtData += ship.isBought ? "1" : "0";
			if (ship.isUsed) {
				isUsed = ship.shipName;
			}
		}
		PlayerPrefs.SetString ("isBought", isBoughtData);
	}

	public static void LoadData () {
		string isBoughtData = PlayerPrefs.GetString ("isBought");
		string isUsed = PlayerPrefs.GetString("isUsed");
		int iterator = 0;
		foreach (ShipDefinition ship in GameManager.instance.ships) {
			ship.isBought = isBoughtData[iterator] == '1' ? true : false;
			if (isUsed == ship.shipName) {
				ship.isUsed = true;
			}
			iterator++;
		}
		FindObjectOfType<ShopUI>().RebuildUI();
	}
}