using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisPlayToolTip : MonoBehaviour {


//	public string myString;
	public Image myText;
	public float fadeTime;
	public bool displayInfo;
	public string helpPathFile;


	void Start () {
//		myText = transform.Find("Image").GetComponent<Image>();
//		myText.color = Color.clear;
		myText.enabled = false;
		displayInfo = false;

		foreach (Transform child in myText.transform) {
			child.gameObject.SetActive (false);
		}

//		myText.text = myString;
	}
	
	// Update is called once per frame
	void Update () {
		FadeText ();
	}

	void OnMouseOver()
	{
		displayInfo = true;
		if (Input.GetKeyDown (KeyCode.F1)) {
			print ("Show help");
			System.Diagnostics.Process.Start (@helpPathFile);
		
		}
	}
	void OnMouseExit(){
		displayInfo = false;
	
	}
	void FadeText(){
		if (displayInfo) {
		
//			myText.text = myString;
//			myText.color = Color.Lerp (myText.color, Color.white, fadeTime * Time.deltaTime);
			myText.enabled = true;
			foreach (Transform child in myText.transform) {
				child.gameObject.SetActive (true);
			}
		
		} else {
//			myText.color = Color.Lerp (myText.color, Color.clear, fadeTime * Time.deltaTime);
			foreach (Transform child in myText.transform) {
				child.gameObject.SetActive (false);
			}

			myText.enabled = false;
		}
	
	}
}
