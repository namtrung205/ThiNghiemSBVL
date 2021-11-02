using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountRotation : MonoBehaviour {

	public float angle1=0;

	public float total=0;

	public GameObject myHand;

	public GameObject kimDongHo;

	public GameObject kimDongHo_1;
	public GameObject kimNganDongHo_1;


	public GameObject kimDongHo_2;
	public GameObject kimNganDongHo_2;


	private float startValue_DongHo_1;
	private float startValue_DongHo_2;



	public float saiSo;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		startValue_DongHo_1 = (float)(kimDongHo_1.gameObject.transform.localEulerAngles.y);
		startValue_DongHo_2 = (float)(kimDongHo_2.gameObject.transform.localEulerAngles.y);


		if (this.gameObject.transform.localEulerAngles.y > 359.9f) {

			this.gameObject.transform.localEulerAngles = new Vector3 (0, 359.9f, 0);

		}


		if (this.gameObject.transform.localEulerAngles.y > 359.9f|| this.gameObject.transform.localEulerAngles.y < 5) {

			this.gameObject.transform.localEulerAngles = new Vector3 (0, 359.9f, 0);

		}


		if (this.gameObject.transform.localEulerAngles.y < 10 && this.gameObject.transform.localEulerAngles.y > 5) {
		
			this.gameObject.transform.localEulerAngles = new Vector3 (0, 10f, 0);
		
		}

		float deltaSaiSo = Random.Range (-saiSo, +saiSo);
	


		float currentAngle = this.gameObject.transform.localEulerAngles.y;

		print ("old: " + angle1);

		print ("current: " + currentAngle);

		total += (currentAngle - angle1);

		kimDongHo.transform.localEulerAngles = new Vector3 (0, currentAngle, 0);
		myHand.transform.Rotate(new Vector3(0, -100*(currentAngle-angle1), 0));


//		kimDongHo_1.transform.localEulerAngles.Rotate (new Vector3 (0,0 ,(currentAngle - angle1)));


		float gocXoayKimDongHo1 = (currentAngle - angle1)/7.86f + deltaSaiSo;
		kimDongHo_1.transform.Rotate (new Vector3 (0,0 ,gocXoayKimDongHo1));
		kimNganDongHo_1.transform.Rotate(new Vector3(0,0,gocXoayKimDongHo1/10));

		float gocXoayKimDongHo2 = ((currentAngle - angle1)/7.86f + deltaSaiSo);
		kimDongHo_2.gameObject.transform.Rotate (new Vector3 (0, 0, gocXoayKimDongHo2));
		kimNganDongHo_2.transform.Rotate(new Vector3(0,0,gocXoayKimDongHo2/10));


		print ("total: " + total);

		angle1 = (float)currentAngle;

		print ("........\n\n");
			

	}
}
