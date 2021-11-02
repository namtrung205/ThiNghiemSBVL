using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRotationCurrent : MonoBehaviour {

	public GameObject myObjectToShow;
	public Text myText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		myText.text = "X: " + Mathf.RoundToInt(this.transform.eulerAngles.x) 
			+ "; Y: " + Mathf.RoundToInt(this.transform.eulerAngles.y)
			+ "; Z: " + Mathf.RoundToInt(this.transform.eulerAngles.z);
	}
}
