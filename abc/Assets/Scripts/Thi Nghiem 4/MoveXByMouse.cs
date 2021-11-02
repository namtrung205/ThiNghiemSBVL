using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveXByMouse : MonoBehaviour {

	private Vector3 mOffset;
	private float mZCoord;

	public float minX = -0.255f;
	public float maxX = -0.035f;

	void OnMouseDown()
	{
		mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		// Store offset = gameobject world pos - mouse world pos
		mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
	}
	private Vector3 GetMouseAsWorldPoint()
	{
		// Pixel coordinates of mouse (x,y)
		Vector3 mousePoint = Input.mousePosition;
		// z coordinate of game object on screen
		mousePoint.z = mZCoord;
		// Convert it to world points
		return Camera.main.ScreenToWorldPoint(mousePoint);
	}
	void OnMouseDrag()
	{
		transform.position = GetMouseAsWorldPoint() + mOffset;
		if (transform.localPosition.x < minX) {
			transform.localPosition = new Vector3 (minX, transform.localPosition.y, transform.localPosition.z);
		}
		if (transform.localPosition.x > maxX) {
			transform.localPosition = new Vector3 (maxX, transform.localPosition.y, transform.localPosition.z);
		}
	}

}
