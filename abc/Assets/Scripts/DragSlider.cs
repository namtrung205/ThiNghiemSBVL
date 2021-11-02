using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSlider : MonoBehaviour {

//	private Vector3 screenPoint;
//	private Vector3 offset;
//
//	void OnMouseDown()
//	{
//		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
//
//		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
//
//	}
//
//	void OnMouseDrag()
//	{
//		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
//
//		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint)+offset;
//		transform.localPosition = new Vector3(curPosition.x,transform.localPosition.y,transform.localPosition.z);
//
//	}


	public float dragSpeed = 0.001f;
	public float maxX = -0.0265f;
	public float minX = -0.2024f;
	Vector3 lastMousePos;

	void OnMouseDown() {
		lastMousePos = Input.mousePosition;
	}

	void OnMouseDrag() {
		Vector3 delta = Input.mousePosition - lastMousePos;
		Vector3 pos = transform.position;
		pos.x += delta.x * dragSpeed;
		pos.x = Mathf.Clamp(pos.y, minX, maxX);
//		transform.position = pos;
		transform.localPosition = new Vector3 (pos.x, transform.localPosition.y, transform.localPosition.z);

		lastMousePos = Input.mousePosition;
	}


	}


