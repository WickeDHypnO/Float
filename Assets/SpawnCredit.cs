using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCredit : MonoBehaviour {

	public List<Transform> creditPoints;
	public void Spawn()
	{
		var rand = Random.Range(0, creditPoints.Count);
		Instantiate(GameManager.instance.credit, creditPoints[rand]);
	}
}
