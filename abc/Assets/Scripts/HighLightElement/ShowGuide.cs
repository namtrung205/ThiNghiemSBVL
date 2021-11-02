using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGuide : MonoBehaviour {
	public string nameTagToShowHide = "BoTriThiNghiem";
	public bool isShow = true;

	public GameObject thuocKep;
	public GameObject thuocThep;

	public GameObject thuocKepDumb;
	public GameObject thuocThepDumb;



	// Use this for initialization
	void Start () {
		isShow = true;
	}

	public void clickToShowHide(){

		foreach (GameObject myGameObj in Resources.FindObjectsOfTypeAll<GameObject>()) 
		{
			if(myGameObj.CompareTag(nameTagToShowHide))
			{
				myGameObj.SetActive (!isShow);
			}
		}

		if (thuocKepDumb.gameObject.activeSelf) {
			thuocKepDumb.SetActive (false);
			thuocKep.SetActive (true);
		} else {
			thuocKepDumb.SetActive (true);
			thuocKep.SetActive (false);
		}

		if (thuocThepDumb.gameObject.activeSelf) {
			thuocThepDumb.SetActive (false);
			thuocThep.SetActive (true);
		} else {
			thuocThepDumb.SetActive (true);
			thuocThep.SetActive (false);
		}

		isShow = !isShow;
	}
}
