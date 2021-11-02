using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutImage : MonoBehaviour {

	public Canvas myStartWindow;
	// the image you want to fade, assign in inspector
	IEnumerator DoFade(){
		CanvasGroup canvasGroup = myStartWindow.GetComponent<CanvasGroup> ();
		while (canvasGroup.alpha > 0) {
			canvasGroup.alpha -= Time.deltaTime / 2f;
			yield return null;
		}

		canvasGroup.interactable = false;
		yield return null;

	}

	public void clickDetective(){
		if (Input.GetMouseButtonDown (1) ||Input.GetMouseButtonDown (2)) {
			StartCoroutine (DoFade ());
		}
	
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		clickDetective ();
	}
}
