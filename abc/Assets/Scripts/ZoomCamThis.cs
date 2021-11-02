using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamThis : MonoBehaviour {

	public Camera myCamToZoom;
	public float stepZoom = 0.2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (myCamToZoom.orthographicSize > 0.01f) 
		{
			if (Input.GetKey (KeyCode.LeftControl)) {

				if (Input.GetAxis ("Mouse ScrollWheel") != 0f) {
					float ScrollAmount = Input.GetAxis ("Mouse ScrollWheel") * stepZoom;
					myCamToZoom.orthographicSize += ScrollAmount;	
				}
			} 

		}
		else{
			myCamToZoom.orthographicSize =0.1f;
		}


	}
}
