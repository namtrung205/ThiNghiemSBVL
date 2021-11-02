using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndSnapable : MonoBehaviour {

	private Vector3 mOffset;
	private float mZCoord;

	public Vector3 topPoint = new Vector3(-0.3904f,1.0f,0.02f);
	public Vector3 botPoint = new Vector3(-0.3904f,0.5f,0.02f);
	public SelectionManager myWeightManager;

	void OnMouseDown(){
		Rigidbody myRig = transform.GetComponent ("Rigidbody") as Rigidbody;
		myRig.isKinematic = true;

		Collider myCol = transform.GetComponent ("Collider") as Collider;
		myCol.enabled = false;

		mZCoord = Camera.main.WorldToScreenPoint (gameObject.transform.position).z;
		mOffset = gameObject.transform.position - GetMouseWorldPos ();
	}

	private Vector3 GetMouseWorldPos(){

		Vector3 mousePoint = Input.mousePosition;

		mousePoint.z = mZCoord;
		return Camera.main.ScreenToWorldPoint (mousePoint);
	}

	void OnMouseDrag(){
		Rigidbody myRig = transform.GetComponent ("Rigidbody") as Rigidbody;
		myRig.isKinematic = true;


		Collider myCol = transform.GetComponent ("Collider") as Collider;
		myCol.enabled = false;

		transform.position = GetMouseWorldPos () + mOffset/5;
	}

	void OnMouseUp(){
		if (transform.position.y > (topPoint.y)) {
			transform.position = topPoint;
		}

		else 
		{
			transform.position = botPoint;
		}

		Rigidbody myRig = transform.GetComponent ("Rigidbody") as Rigidbody;
		myRig.isKinematic = false;


		Collider myCol = transform.GetComponent ("Collider") as Collider;
		myCol.enabled = true;
	}
}
