using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapAngle : MonoBehaviour {

	public float angleSnap = 15f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float xAngle = transform.localEulerAngles.x;
		float yAngle = transform.localEulerAngles.y;
		float zAngle = transform.localEulerAngles.z;

		float xSnap = (Mathf.RoundToInt (xAngle / angleSnap))*angleSnap;
		float ySnap = (Mathf.RoundToInt (yAngle / angleSnap))*angleSnap;
		float zSnap = (Mathf.RoundToInt (zAngle / angleSnap))*angleSnap;


		transform.localEulerAngles = new Vector3 (xSnap, ySnap, zSnap);
	}
}
