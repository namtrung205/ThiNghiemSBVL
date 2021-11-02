using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressSwithButton : MonoBehaviour {

	public GameObject firstCT38;
	public Image myImageToFill;
	public Image myImageToShow;

	public GameObject ngamDuoi;
	private Vector3 p1_Ngam;
	private Vector3 p2_Ngam;

	public GameObject thanhCT38;
	private Vector3 p1_Ct38;
	private Vector3 p2_Ct38;


	public GameObject CT38Tren;
	public GameObject CT38Duoi;


	public float distance = -0.01f;

	public float lerpTime = 2;

	public float currentLerpTime = 0;

	public bool hasClick = false;

	public bool keyHit = false;

	void Start(){
		p1_Ngam = ngamDuoi.transform.position;
		p2_Ngam = ngamDuoi.transform.position + Vector3.up * distance;
	
		p1_Ct38 = thanhCT38.transform.position;
		p2_Ct38 = thanhCT38.transform.position + Vector3.up * distance;


	}

	void Update(){
		if (hasClick) {
			currentLerpTime += Time.deltaTime;
			if (currentLerpTime >= lerpTime) {
				currentLerpTime = lerpTime;
			}
			float Perc = currentLerpTime / lerpTime;

			if (Perc > 0.7) {
				Perc = 1;}
			ngamDuoi.transform.position = Vector3.Lerp (p1_Ngam, p2_Ngam, Perc);
			thanhCT38.transform.position = Vector3.Lerp (p1_Ct38, p2_Ct38, Perc);

			myImageToFill.fillAmount = Perc*1.3f;

		}
	}

	void OnMouseDown(){

		if (firstCT38.gameObject.GetComponent<ClickToShowAndHideSelf> ().clicked) {
		
			if (!hasClick) {

				//set Image
				List<Sprite> myListChart = new List<Sprite> ();

				print("num sprite: " + Resources.LoadAll("TN1", typeof(Sprite)).Length);
				//Load all chart sprite
				foreach(Sprite myChart in Resources.LoadAll("TN1", typeof(Sprite)))
				{
					if(myChart.name.Contains("TN1_Chart"))
					{
						myListChart.Add (myChart);
					}
					print (myChart.name);
				}

				int myChartIndex = Random.Range (0, myListChart.Count);

				myImageToFill.overrideSprite = myListChart [myChartIndex];
				myImageToShow.overrideSprite = myListChart [myChartIndex];


				print ("justClicked");
				myImageToFill.type = Image.Type.Filled;
				myImageToFill.fillMethod = Image.FillMethod.Horizontal;
				CT38Tren.tag = "ToolTip";
				CT38Duoi.tag = "ToolTip";


				hasClick = !hasClick;

			} else {
				print ("Have Click");
			}
		}



	}


}
