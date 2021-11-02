using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToHideSelfByMove : MonoBehaviour {

    public GameObject alObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnMouseDown()
    {


        if (Input.GetKey(KeyCode.LeftControl))
        {

            alObject.SetActive(true);

            this.gameObject.SetActive(false);

            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,
                this.gameObject.transform.position.y - 10000f,
                this.gameObject.transform.position.z);

        }



    }
}
