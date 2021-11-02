using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAngleStart : MonoBehaviour {
	public float minAngle;
	public float maxAngle;
	// Use this for initialization
	void Start () {
		this.transform.localEulerAngles = new Vector3 (this.transform.localEulerAngles.x,
			Random.Range(minAngle, maxAngle),
			this.transform.localEulerAngles.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
