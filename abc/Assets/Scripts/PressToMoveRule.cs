using UnityEngine;
using System.Collections;
public class PressToMoveRule : MonoBehaviour
{

	void Update()
	{

		//Move X+
		if (Input.GetKey(KeyCode.X)) 
		{

			this.transform.position +=(new Vector3(0.001f, 0f, 0f));
		}

		//Move X-
		if (Input.GetKey(KeyCode.X) && Input.GetKey (KeyCode.Minus) ) 
		{

			this.transform.position +=(new Vector3( -0.001f,0, 0));
		}


		//Move Y+
		if (Input.GetKey(KeyCode.Y)) 
		{

			this.transform.position +=(new Vector3(0f, 0.001f, 0f));
		}


		//Move Y-
		if (Input.GetKey(KeyCode.Y) && Input.GetKey (KeyCode.Minus)   ) 
		{

			this.transform.position +=(new Vector3(0f, -0.001f, 0));
		}


		//Move Z+
		if (Input.GetKey(KeyCode.Z)) 
		{

			this.transform.position +=(new Vector3(0f, 0f, 0.001f));
		}

		//Move Z-
		if (Input.GetKey(KeyCode.Z) && Input.GetKey (KeyCode.Minus)   ) 
		{

			this.transform.position +=(new Vector3(0f, 0f, -0.001f));
		}


		//R Z
		if (Input.GetKey(KeyCode.R) && Input.GetKeyDown (KeyCode.F3)  ) 
		{

			this.transform.Rotate(new Vector3(0f, 0f, 30f));
		}

		//R X
		if (Input.GetKey(KeyCode.R) && Input.GetKeyDown (KeyCode.F1)  ) 
		{

			this.transform.Rotate(new Vector3(30f, 0f, 0f));
		}
		//R Y
		if (Input.GetKey(KeyCode.R) && Input.GetKeyDown (KeyCode.F2)  ) 
		{

			this.transform.Rotate(new Vector3(0f, 30f, 0));
		}


	}



}