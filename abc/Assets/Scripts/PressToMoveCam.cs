using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressToMoveCam : MonoBehaviour {
	public float moveStep = 0.002f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {



//		//Move X
//		if (Input.GetKey (KeyCode.Q) ) 
//		{
//
//			this.transform.position += new Vector3 (0, 0, moveStep);
//		}
//
//		//Move backward
//		if (Input.GetKey (KeyCode.E) )
//		{
//			this.transform.position -= new Vector3 (0, 0, moveStep);
//		}

		//Move Y
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{

			this.transform.position -= new Vector3 (0, 0, moveStep);
		}

		//Move backward
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			this.transform.position += new Vector3 (0, 0, moveStep);
		}


		//Move forward
		if (Input.GetKey (KeyCode.UpArrow)) 
		{

			this.transform.position += new Vector3 (0, moveStep, 0);
		}

		//Move backward
		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			this.transform.position -= new Vector3 (0, moveStep, 0);
		}



	}
}
