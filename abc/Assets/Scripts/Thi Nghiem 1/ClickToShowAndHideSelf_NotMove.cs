using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToShowAndHideSelf_NotMove : MonoBehaviour {

	public GameObject alObject;

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

			this.gameObject.SetActive (false);


		}



	}
}
