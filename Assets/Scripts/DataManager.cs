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
		PlayerPrefs.SetString ("isBoughtShips", isBoughtData);
		PlayerPrefs.SetString ("isUsedShip", isUsed);
		foreach (TrailDefinition trail in GameManager.instance.trails) {
			isBoughtData += trail.isBought ? "1" : "0";
			if (trail.isUsed) {
				isUsed = trail.trailName;
			}
		}
		PlayerPrefs.SetString ("isBoughtTrails", isBoughtData);
		PlayerPrefs.SetString ("isUsedTrail", isUsed);
	}

	public static void LoadData () {
		string isBoughtData = PlayerPrefs.GetString ("isBoughtShips");
		string isUsed = PlayerPrefs.GetString ("isUsedShip");
		int iterator = 0;
		foreach (ShipDefinition ship in GameManager.instance.ships) {
			ship.isBought = isBoughtData[iterator] == '1' ? true : false;
			if (isUsed == ship.shipName) {
				ship.isUsed = true;
			} else {
				ship.isUsed = false;
			}
			iterator++;
		}
		FindObjectOfType<ShopUI> ().RebuildShipUI ();
		isBoughtData = PlayerPrefs.GetString ("isBoughtTrails");
		isUsed = PlayerPrefs.GetString ("isUsedTrail");
		iterator = 0;
		foreach (TrailDefinition trail in GameManager.instance.trails) {
			trail.isBought = isBoughtData[iterator] == '1' ? true : false;
			if (isUsed == trail.trailName) {
				trail.isUsed = true;
			} else {
				trail.isUsed = false;
			}
			iterator++;
		}
		FindObjectOfType<ShopUI> ().RebuildTrailUI ();
	}

	public static void SaveDistanceAndCredits () {
		PlayerPrefs.SetFloat ("distance", GameManager.instance.totalDistance);
		PlayerPrefs.SetFloat ("recordDistance", GameManager.instance.recordDistance);
		PlayerPrefs.SetFloat ("credits", GameManager.instance.credits);
	}

	public static void LoadDistanceAndCredits () {
		GameManager.instance.totalDistance = PlayerPrefs.GetFloat ("distance");
		GameManager.instance.recordDistance = PlayerPrefs.GetFloat ("recordDistance");
		GameManager.instance.credits = PlayerPrefs.GetFloat ("credits");
	}
}