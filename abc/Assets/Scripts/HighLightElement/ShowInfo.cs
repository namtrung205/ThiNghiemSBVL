using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ShowInfo : MonoBehaviour {

	
	//	public string myString;
	public Text myText;
	public Text myTextToShow;

//	public Text rotationCurrent;

	public bool displayInfo;
	public string helpPathFile;


	void Start () {
//		myText.enabled = false;
		displayInfo = false;
		string currentFolder = Directory.GetCurrentDirectory ();

		helpPathFile = Path.Combine (currentFolder, helpPathFile);
	}

	// Update is called once per frame
	void Update () {
//		FadeText ();
	}

	void OnMouseOver()
	{
		displayInfo = true;
        
		myTextToShow.text = myText.text;
//		rotationCurrent.text = "Rotation-" + "X: " + Mathf.RoundToInt(this.transform.eulerAngles.x) 
//			+ " Y: " + Mathf.RoundToInt(this.transform.eulerAngles.y)
//			+ " Z: " + Mathf.RoundToInt(this.transform.eulerAngles.z);
		if (Input.GetKeyDown (KeyCode.F1)) 
		{
			print ("Show help");

			System.Diagnostics.Process.Start (@helpPathFile);

		}
	}
	void OnMouseExit(){
		displayInfo = false;
		myTextToShow.text = "";
//		rotationCurrent.text = "Rotation-";
	}

}
