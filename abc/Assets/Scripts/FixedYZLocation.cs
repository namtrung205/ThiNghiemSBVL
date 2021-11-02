using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedYZLocation : MonoBehaviour {
	public float YFixed = -0.0f;
	public float ZFixed = -0.000154f;
	public float XMax = -0.00103f;
	public float XMin = -0.00803f;
	// Use this for initialization
	void Start () {
//		transform.localPosition = new Vector3 (-0.07f, -0.0043f, 0f);
		
	}
	
	// Update is called once per frame
	void Update () {

		//Transform
		if (transform.localPosition.y != YFixed || transform.localPosition.z != ZFixed) {
			
			transform.localPosition = new Vector3 (transform.localPosition.x, YFixed, ZFixed);
		
		} 

		if (transform.localPosition.x >XMax) {

			transform.localPosition = new Vector3 (XMax, YFixed, ZFixed);

		}
		if (transform.localPosition.x <XMin) {
			transform.localPosition = new Vector3 (XMin, YFixed, ZFixed);
		}

		//Rotate
		if (transform.localRotation.x != 0f || transform.localRotation.y != 0f || transform.localRotation.z != -0f) {

			transform.localEulerAngles = new Vector3 (0f, 0f, 0f);

		} 

	}
}
