using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToShowAndHideSelf : MonoBehaviour {
	public GameObject alObject;
	public GameObject buttonPress;
	public bool clicked = false;

	public Vector3 myAfterPos = new Vector3(-0.4594f, 1.423f,0.0382f);

	// Use this for initialization
	void Start () {
		this.gameObject.SetActive (true);
		alObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){

		if (Input.GetKey (KeyCode.LeftControl)) {
		
			alObject.SetActive (true);


			this.gameObject.transform.position = myAfterPos;

			this.clicked = true;
		
		}

	}
}
