using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldMouseToMove : MonoBehaviour {

	float moveSpeed = 0.02f;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (2)) {
			transform.Translate (Vector3.right * -Input.GetAxis ("Mouse X") * moveSpeed);
			transform.Translate (transform.up * -Input.GetAxis ("Mouse Y") * moveSpeed, Space.World);
		}
	}
}
