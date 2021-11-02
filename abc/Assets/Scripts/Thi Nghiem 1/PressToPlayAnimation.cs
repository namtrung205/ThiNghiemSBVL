using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressToPlayAnimation : MonoBehaviour {

    public GameObject myCT38Animation;
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

    public GameObject warningPressWindow;
    public GameObject okPressWindow;

    public GameObject soundObject;
    public GameObject soundObjectBreak;

    //	public Button buttonToShowVideoTheory;

    public float distance = -0.01f;

    public float lerpTime = 2;

    public float currentLerpTime = 0;

    public bool hasClick = false;
    bool breaked = false;

    public bool keyHit = false;

    void Start()
    {
        p1_Ngam = ngamDuoi.transform.position;
        p2_Ngam = ngamDuoi.transform.position + Vector3.up * distance;

        p1_Ct38 = thanhCT38.transform.position;
        p2_Ct38 = thanhCT38.transform.position + Vector3.up * distance;


    }

    void Update()
    {
        if (hasClick)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime >= lerpTime)
            {
                currentLerpTime = lerpTime;
            }
            float Perc = currentLerpTime / lerpTime;

            if (Perc > 0.7)
            {
                //Play Sound

                var pressAudioSourceBreak = soundObjectBreak.GetComponent<AudioSource>();

                var pressAudioSource = soundObject.GetComponent<AudioSource>();

                if (pressAudioSourceBreak != null && breaked==false && pressAudioSource!=null)
                {
                    pressAudioSourceBreak.loop = false;
                    pressAudioSourceBreak.Play();

                    pressAudioSource.Stop();

                    breaked = true;
                }
                Perc = 1;
                CT38Duoi.gameObject.SetActive(true);
                CT38Tren.gameObject.SetActive(true);
                myImageToShow.gameObject.SetActive(true);
                myCT38Animation.SetActive(false);
            }
            ngamDuoi.transform.position = Vector3.Lerp(p1_Ngam, p2_Ngam, Perc);
            thanhCT38.transform.position = Vector3.Lerp(p1_Ct38, p2_Ct38, Perc);

            myImageToFill.fillAmount = 0.18f+Perc * 1.0f;

//			if (Perc == 1) {
//			
//				buttonToShowVideoTheory.gameObject.SetActive (true);
//				buttonToShowVideoTheory.onClick.Invoke ();
//				buttonToShowVideoTheory = null;
//			}

        }
    }

    void OnMouseDown()
    {

        warningPressWindow.gameObject.SetActive(false);
        okPressWindow.gameObject.SetActive(false);

        if (firstCT38.gameObject.GetComponent<ClickToShowAndHideSelf>().clicked)
        {

            if (!hasClick)
            {
                warningPressWindow.gameObject.SetActive(false);
                okPressWindow.gameObject.SetActive(true);


                //set Image
                List<Sprite> myListChart = new List<Sprite>();
				List<Sprite> myListChartFull = new List<Sprite>();

				Dictionary<Sprite, Sprite> myDicChart = new Dictionary<Sprite, Sprite> ();


                print("num sprite: " + Resources.LoadAll("TN1", typeof(Sprite)).Length);
                //Load all chart sprite
                foreach (Sprite myChart in Resources.LoadAll("TN1", typeof(Sprite)))
                {
                    if (myChart.name.Contains("TN1_Chart"))
                    {
                        myListChart.Add(myChart);
						string myFullPathChart = @"TN1/TN1_Full_" + myChart.name.Split ('_')[2];

						Sprite myFullChart = Resources.Load<Sprite> (myFullPathChart);

						myDicChart.Add (myChart, myFullChart);
                    }
                }

//				int myChartIndex = Random.Range(0, myListChart.Count);
//
//				myImageToFill.overrideSprite = myListChart[myChartIndex];
//				myImageToShow.overrideSprite = myListChart[myChartIndex];


//				int myChartIndex = Random.Range(0, myDicChart.Keys.Count);

				List<Sprite> myListKey = new List<Sprite> ();

				foreach (Sprite mySpriteKey in myDicChart.Keys) {
					myListKey.Add (mySpriteKey);
				}

				int myChartIndex = Random.Range(0, myListKey.Count);


				print ("Chart: " + myListKey [myChartIndex].name);
				print ("Full Chart: "  + myDicChart[myListKey[myChartIndex]].name);

				myImageToShow.gameObject.SetActive (false);


				myImageToFill.overrideSprite = myListKey[myChartIndex];
				myImageToShow.overrideSprite = myDicChart[myListKey[myChartIndex]];


                print("justClicked");
                myImageToFill.type = Image.Type.Filled;
                myImageToFill.fillMethod = Image.FillMethod.Horizontal;
                CT38Tren.tag = "ToolTip";
                CT38Duoi.tag = "ToolTip";

                CT38Duoi.SetActive(false);
                CT38Tren.SetActive(false);
                myCT38Animation.SetActive(true);

                myCT38Animation.GetComponent<Animator>().Play("Press");

                //Play Sound
                var pressAudioSource = soundObject.GetComponent<AudioSource>();
                if (pressAudioSource != null)
                {
                    pressAudioSource.loop = false;
                    pressAudioSource.Play();
                }

                hasClick = !hasClick;



            }
            else
            {
                print("Have Click");
            }
        }
        else
        {
            warningPressWindow.gameObject.SetActive(true);
            okPressWindow.gameObject.SetActive(false);
        }
    }

}
