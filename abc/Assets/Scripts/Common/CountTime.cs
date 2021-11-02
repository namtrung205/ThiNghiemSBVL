using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CountTime : MonoBehaviour {
	public float timer;
	public Text textBox;
	// Use this for initialization
	void Start () {
		string minutes = Mathf.Floor(timer / 60).ToString("00");
		string seconds = (timer % 60).ToString("00");
		textBox.text = String.Format("{0}:{1}", minutes, seconds);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		string minutes = Mathf.Floor(timer / 60).ToString("00");
		string seconds = (timer % 60).ToString("00");
		textBox.text = String.Format("{0}:{1}", minutes, seconds);
	}
}
