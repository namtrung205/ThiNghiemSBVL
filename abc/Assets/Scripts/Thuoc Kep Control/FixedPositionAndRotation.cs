using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPositionAndRotation : MonoBehaviour {

	private Vector3 myOriginPosition;
	private Vector3 myOriginAngle;

	public bool fixedX = true;
	public bool fixedY = true;
	public bool fixedZ = true;
	public bool fixedAngX = true;
	public bool fixedAngY = true;
	public bool fixedAngZ = true;

	public float startX;
	public float startY;
	public float startZ;
	public float startAX;
	public float startAY;
	public float startAZ;


	// Use this for initialization
	void Start () {
		myOriginPosition = this.transform.localPosition;

		startX = (float)myOriginPosition.x;
		startY = (float)myOriginPosition.y;
		startZ = (float)myOriginPosition.z;


		myOriginAngle = this.transform.localEulerAngles;

		startAX = (float)myOriginAngle.x;
		startAY = (float)myOriginAngle.y;
		startAZ = (float)myOriginAngle.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (fixedX) {
			this.transform.localPosition = new Vector3 (startX, this.transform.localPosition.y, this.transform.localPosition.z);
		}
		if (fixedY) {
			this.transform.localPosition = new Vector3 ( this.transform.localPosition.x, startY, this.transform.localPosition.z);
		}

		if (fixedZ) {
			this.transform.localPosition = new Vector3 ( this.transform.localPosition.x, this.transform.localPosition.y, startZ);
		}

		if (fixedAngX) {
			this.transform.localEulerAngles = new Vector3 (startAX, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);
		}
		if (fixedAngY) {
			this.transform.localEulerAngles = new Vector3 ( this.transform.localEulerAngles.x, startAY, this.transform.localEulerAngles.z);
		}

		if (fixedAngZ) {
			this.transform.localEulerAngles = new Vector3 ( this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, startAZ);
		}

	}
}
