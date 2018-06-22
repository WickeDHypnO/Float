using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDefinition : ScriptableObject {

	public string shipName;
	public GameObject shipPrefab;
	public Sprite shipIcon;
	public float shipPrice;
	public bool isBought;
	public bool isUsed;
#if UNITY_EDITOR
	[UnityEditor.MenuItem ("Tools/Create new ship")]
	public static void CreateObject () {
		ShipDefinition asset = (ShipDefinition)ScriptableObject.CreateInstance (typeof(ShipDefinition));

        UnityEditor.AssetDatabase.CreateAsset (asset, "Assets/ShipDefinitions/New Ship.asset");
		UnityEditor.AssetDatabase.SaveAssets ();

		UnityEditor.EditorUtility.FocusProjectWindow ();

		UnityEditor.Selection.activeObject = asset;
	}
#endif
}