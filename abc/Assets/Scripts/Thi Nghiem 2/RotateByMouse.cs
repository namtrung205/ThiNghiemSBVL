using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByMouse : MonoBehaviour {

	float rotateSpeed = 1f;

	void OnMouseDrag(){
	
		float rotX = Input.GetAxis ("Mouse X") * rotateSpeed * Mathf.Deg2Rad;
		float rotY = Input.GetAxis ("Mouse Y") * rotateSpeed * Mathf.Deg2Rad;

//		transform.RotateAround (Vector3.up, -rotX);
		transform.RotateAround (Vector3.forward, -rotY);
	}
}
