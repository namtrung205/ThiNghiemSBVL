
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{


	//	public string myString;
	public string myText;
	public Text myTextToShow;


	public string helpPathFile;


	void Start () {
		myTextToShow.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		//		FadeText ();
	}
		

	public void OnPointerEnter(PointerEventData eventData)
	{  		
		myTextToShow.gameObject.SetActive(true);
		myTextToShow.text = myText;
		myTextToShow.transform.position = this.transform.position + new Vector3(55,0,0);
	
	}

	public void OnPointerExit(PointerEventData eventData)
	{    
		myTextToShow.text = "";
		myTextToShow.gameObject.SetActive(false);
	}




}