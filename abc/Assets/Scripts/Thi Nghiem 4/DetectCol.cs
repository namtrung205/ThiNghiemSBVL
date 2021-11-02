using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCol : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		Debug.Log ("Collied With: " + col.gameObject.name);
	}
	void OnCollisionExit(Collision col){
		Debug.Log ("Collied Without: " + col.gameObject.name);
	}
}
