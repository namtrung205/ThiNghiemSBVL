using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressToMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float moveStep = 0.02f;


		//Move X
		if (Input.GetKey (KeyCode.Q) ) 
		{
			
			this.transform.position += new Vector3 (0, 0, moveStep);
		}

		//Move backward
		if (Input.GetKey (KeyCode.E) )
		{
			this.transform.position -= new Vector3 (0, 0, moveStep);
		}

		//Move Y
		if (Input.GetKey (KeyCode.A)) 
		{

			this.transform.position -= new Vector3 (moveStep, 0, 0);
		}

		//Move backward
		if (Input.GetKey (KeyCode.D)) 
		{
			this.transform.position += new Vector3 (moveStep, 0, 0);
		}


		//Move forward
		if (Input.GetKey (KeyCode.W)) 
		{

			this.transform.position += new Vector3 (0, moveStep, 0);
		}

		//Move backward
		if (Input.GetKey (KeyCode.S)) 
		{
			this.transform.position -= new Vector3 (0, moveStep, 0);
		}



	}
}
