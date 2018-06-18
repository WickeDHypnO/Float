using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public float multiplier = 2f;
	bool moving = false;
	public RectTransform movementPanel;
	float referenceValue;
	float lastValue;
	public Vector2 maxPositions;
	public Vector2 referencePosition;
	public Vector2 referenceTouchPosition;
	Vector2 offset;
	void Move (Vector2 touchOffset) {
		offset = referencePosition + touchOffset * multiplier;
		if (offset.x > maxPositions.x) offset.x = maxPositions.x;
		else if (offset.x < -maxPositions.x) offset.x = -maxPositions.x;
		if (offset.y > maxPositions.y) offset.y = maxPositions.y;
		else if (offset.y < -maxPositions.y) offset.y = -maxPositions.y;
		transform.position = offset;
	}

	public void StartMovement () {
		referencePosition = transform.position;
#if UNITY_EDITOR
		referenceTouchPosition = Input.mousePosition;
#else
		referenceTouchPosition = Input.touches[0].position;
#endif
		moving = true;
	}

	public void StopMovement () {
		moving = false;
	}

	private void Update () {
		if (moving) {
#if UNITY_EDITOR
			Move ((Vector2) Input.mousePosition - referenceTouchPosition);
#else
			Move (Input.touches[0].position - referenceTouchPosition);
#endif
		}
	}
}