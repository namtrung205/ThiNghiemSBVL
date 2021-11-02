using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MainCalculateFunc : MonoBehaviour {

	public GameObject leftHanger;
	public GameObject rightHanger;


	public GameObject weightLeft;
	public GameObject weightRight;

	public GameObject tensometerTren;
	public GameObject tensometerDuoi;

	public Text myMomentUpdate;

	public Text myfirstMoment;

	public Text myDeltamoment;

	public float factor = 4.2f;

	float firstMoment;

	// Use this for initialization
	void Start () {
		firstMoment = 0.5f * ((0.1f) * (0.3f-leftHanger.transform.localPosition.x) + (0.1f) * (0.3f+rightHanger.transform.localPosition.x));
	}
	
	// Update is called once per frame
	void Update () {
		float l1 = (0.3f - leftHanger.transform.localPosition.x);
		float l2 = 0.3f +rightHanger.transform.localPosition.x;


		float countWeightLeft = weightLeft.GetComponent<CountWeight> ().weightCount;
		float countWeightRight= weightRight.GetComponent<CountWeight> ().weightCount;


		float momenentValue = 0.5f * ((0.1f + countWeightLeft * 2) * l1 + (0.1f + countWeightRight *2 )* l2);
//		float momenentValue = 0.5f;
		myMomentUpdate.text = "current: " + momenentValue.ToString();

		myfirstMoment.text = "first: " + firstMoment.ToString();
		myDeltamoment.text = "delta: " + (momenentValue-firstMoment).ToString();


		tensometerTren.transform.localEulerAngles = new Vector3 (-1*factor*(momenentValue-firstMoment),
			tensometerTren.transform.localEulerAngles.y, tensometerTren.transform.localEulerAngles.z);


		tensometerDuoi.transform.localEulerAngles = new Vector3 (factor*(momenentValue-firstMoment),
			tensometerDuoi.transform.localEulerAngles.y, tensometerDuoi.transform.localEulerAngles.z);
		

	}
}
