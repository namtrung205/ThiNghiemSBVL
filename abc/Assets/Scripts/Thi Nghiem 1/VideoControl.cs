using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;


public class VideoControl : MonoBehaviour {
	
	public GameObject myImageTex;
	public GameObject myPlayer;
	private bool isShowAndPlay = false;

//	public CanvasGroup myGroupVideo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public RawImage myVideoImage;
	// the image you want to fade, assign in inspector
	IEnumerator DoFade(){
		CanvasGroup canvasGroup = myVideoImage.GetComponent<CanvasGroup> ();
		while (canvasGroup.alpha > 0) {
			canvasGroup.alpha -= Time.deltaTime / 2f;
			yield return null;
		}

		canvasGroup.interactable = false;
		yield return null;

	}

	IEnumerator UnDoFade(){
		CanvasGroup canvasGroup = myVideoImage.GetComponent<CanvasGroup> ();
		while (canvasGroup.alpha < 1) {
			canvasGroup.alpha += Time.deltaTime / 2f;
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


	public void ClickToPlayAndStop()
	{

		VideoPlayer myVideoPlayer = myPlayer.GetComponent<VideoPlayer> ();
		if (!isShowAndPlay) {



			myImageTex.SetActive (true);
			myVideoImage.GetComponent<CanvasGroup> ().alpha = 0;
			myVideoPlayer.Play ();
			StartCoroutine (UnDoFade ());

			isShowAndPlay = !isShowAndPlay;

		
		} else {
			myVideoPlayer.Stop ();
			myImageTex.SetActive (false);
			isShowAndPlay = !isShowAndPlay;
//			StartCoroutine (DoFade ());
		}


	}
}
