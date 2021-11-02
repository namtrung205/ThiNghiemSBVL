using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotateY : MonoBehaviour {

	public float rangeSaiSo = 0.01f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float saiSoRand = Random.Range (-rangeSaiSo, rangeSaiSo);

		this.transform.localEulerAngles = new Vector3 (this.transform.localEulerAngles.x ,
			this.transform.localEulerAngles.y + saiSoRand,
			this.transform.localEulerAngles.z);

		print (saiSoRand);
	}
}
