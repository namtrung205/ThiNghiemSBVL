﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiiboarScript : MonoBehaviour {

	public Camera myCamera;

	
	// Update is called once per frame
	void Update () {
		transform.LookAt (transform.position + myCamera.transform.rotation * Vector3.forward, myCamera.transform.rotation * Vector3.up);
	}
}
