using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ClickToShowAndHide : MonoBehaviour {

	public Button showBoTri;
	public Text myText;
    public GameObject oldObject;
	public void HideAndShow(GameObject targetObject)
	{
		if (targetObject.activeSelf) {
			targetObject.SetActive (false);
            if (myText != null)
            {
                myText.text = "Cheá ñoä quan saùt";
                print("hide");
            }
		}
        else
        {
			targetObject.SetActive (true);
            if (myText != null)
            {
                myText.text = "Cheá ñoä thöïc haønh";
                print("show");
            }
		}
        //Hide Old object
        if (oldObject != null)
        {
            oldObject.SetActive(false);
        }
        
        if (showBoTri != null)
        {
            showBoTri.onClick.Invoke();
        }
	}

}
