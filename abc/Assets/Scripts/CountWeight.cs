using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountWeight : MonoBehaviour {
	public GameObject[] weights;
	public int weightCount;
	public string byTagName = "WeightLeft";

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		weightCount = 0;
		//find all object with tag
		weights = GameObject.FindGameObjectsWithTag(byTagName);
		foreach (GameObject weight in weights) {
		
			if (weight.transform.position.y > 0.5f) {
				weightCount++;
			}
		}

		print ("Weight: " + byTagName + weightCount);
	}
}
