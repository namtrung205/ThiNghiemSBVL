using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GetToDay : MonoBehaviour {
	public Text myText;
	// Use this for initialization
	void Start () {
		myText.text = System.DateTime.Now.Date.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
