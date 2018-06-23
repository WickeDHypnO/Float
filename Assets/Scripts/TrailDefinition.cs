using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailDefinition : ScriptableObject {
	public string trailName;
	public Sprite trailIcon;
	public Material trailMaterial;
	public Gradient trailColor;
	public float trailPrice;
	public bool isBought;
	public bool isUsed;
#if UNITY_EDITOR
	[UnityEditor.MenuItem ("Tools/Create new trail")]
	public static void CreateObject () {
		TrailDefinition asset = (TrailDefinition)ScriptableObject.CreateInstance (typeof(TrailDefinition));

        UnityEditor.AssetDatabase.CreateAsset (asset, "Assets/TrailDefinitions/New Trail.asset");
		UnityEditor.AssetDatabase.SaveAssets ();

		UnityEditor.EditorUtility.FocusProjectWindow ();

		UnityEditor.Selection.activeObject = asset;
	}
#endif
}
