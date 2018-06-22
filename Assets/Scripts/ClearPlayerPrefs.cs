using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPlayerPrefs : MonoBehaviour {
#if UNITY_EDITOR
	[UnityEditor.MenuItem ("Tools/Clear player prefs")]
	public static void ClearPrefs () {
		PlayerPrefs.DeleteAll ();
	}
#endif
}