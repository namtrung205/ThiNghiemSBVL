using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using SFB;

public class SaveInputValueToTextTN5 : MonoBehaviour {
	public string nameOutPutFile = @"Templates\OutPut_TN5.txt";

    public int resWidth = 2550;
    public int resHeight = 3300;
    public Camera screenShotCam;

    public GameObject originReport;
    public GameObject cloneReport;

    public string txtFile = "";
	public string templateFile = "";
	public string tenSinhVien = "";

	public InputField TN5_Check;
	public InputField TN5_Tol1;
	public InputField TN5_Tol2;

	public InputField TN5_l;
	public InputField TN5_b;
	public InputField TN5_h;
	public InputField TN5_a;

	public InputField TN5_VD_01;
	public InputField TN5_VD_21;
	public InputField TN5_VD_41;
	public InputField TN5_VD_61;
	public InputField TN5_VD_42;
	public InputField TN5_VD_22;
	public InputField TN5_VD_02;


	public InputField TN5_DVD_02;
	public InputField TN5_DVD_24;
	public InputField TN5_DVD_46;
	public InputField TN5_DVD_64;
	public InputField TN5_DVD_42;
	public InputField TN5_DVD_20;

	public InputField TN5_VB_01;
	public InputField TN5_VB_21;
	public InputField TN5_VB_41;
	public InputField TN5_VB_61;
	public InputField TN5_VB_42;
	public InputField TN5_VB_22;
	public InputField TN5_VB_02;


	public InputField TN5_DVB_02;
	public InputField TN5_DVB_24;
	public InputField TN5_DVB_46;
	public InputField TN5_DVB_64;
	public InputField TN5_DVB_42;
	public InputField TN5_DVB_20;

	public InputField TN5_Jx;
	public InputField TN5_YB_Lt;
	public InputField TN5_PhiA;
	public InputField TN5_DVB_Tb;
	public InputField TN5_DVD_Tb;

	public InputField TN5_YB_Tt;
	public InputField TN5_DphiA_Tt;

	public InputField TN5_Comments;

	public GameObject warningWindow;
    public GameObject exportPDFWindow;
    //Canbe Check if begin TN3
    public Text timer;


    public void SaveDataToText() {

        warningWindow.gameObject.SetActive(false);
        exportPDFWindow.gameObject.SetActive(false);

        Dictionary<string, string> myDicOut = new Dictionary<string, string> ();

		string currentFolder = Directory.GetCurrentDirectory ();

		string pathOutPutFile = Path.Combine (currentFolder, nameOutPutFile);


        //Kiem tra so lieu tinh
        float value_DVD = 13.91f;
        float value_DVB = 27.00f;

        //Kiem tra ket qua tinh voi sai so <10%

        bool itemCheck_1 = CheckTolerance(TN5_l, 600f, 0.15f); //Fix cứng giá trị đúng
        bool itemCheck_2 = CheckTolerance(TN5_b, 20f, 0.15f);
        bool itemCheck_3 = CheckTolerance(TN5_h, 10f, 0.15f);
        bool itemCheck_4 = CheckTolerance(TN5_a, 103.0f, 0.15f);


        bool itemCheck_5 = CheckTolerance(TN5_DVD_02, value_DVD, 0.15f);
        bool itemCheck_6 = CheckTolerance(TN5_DVD_24, value_DVD, 0.15f);
        bool itemCheck_7 = CheckTolerance(TN5_DVD_46, value_DVD, 0.15f);
        bool itemCheck_8 = CheckTolerance(TN5_DVD_64, value_DVD, 0.15f);
        bool itemCheck_9 = CheckTolerance(TN5_DVD_42, value_DVD, 0.15f);
        bool itemCheck_10 = CheckTolerance(TN5_DVD_20, value_DVD, 0.15f);


        bool itemCheck_11 = CheckTolerance(TN5_DVB_02, value_DVB, 0.15f);
        bool itemCheck_12 = CheckTolerance(TN5_DVB_24, value_DVB, 0.15f);
        bool itemCheck_13 = CheckTolerance(TN5_DVB_46, value_DVB, 0.15f);
        bool itemCheck_14 = CheckTolerance(TN5_DVB_64, value_DVB, 0.15f);
        bool itemCheck_15 = CheckTolerance(TN5_DVB_42, value_DVB, 0.15f);
        bool itemCheck_16 = CheckTolerance(TN5_DVB_20, value_DVB, 0.15f);

        //Kiem tra cac o khong can check value chi can check empty
        bool itemCheck_17 = CheckTolerance(TN5_VD_01, -1.0f, 0.15f,true);
        bool itemCheck_18 = CheckTolerance(TN5_VD_21, -1.0f, 0.15f,true);
        bool itemCheck_19 = CheckTolerance(TN5_VD_41, -1.0f, 0.1f, true);
        bool itemCheck_20 = CheckTolerance(TN5_VD_61, -1.0f, 0.1f, true);
        bool itemCheck_21 = CheckTolerance(TN5_VD_42, -1.0f, 0.1f, true);
        bool itemCheck_22 = CheckTolerance(TN5_VD_22, -1.0f, 0.1f, true);
        bool itemCheck_23 = CheckTolerance(TN5_VD_02, -1.0f, 0.1f, true);

        bool itemCheck_24 = CheckTolerance(TN5_VB_01, -1.0f, 0.1f, true);
        bool itemCheck_25 = CheckTolerance(TN5_VB_21, -1.0f, 0.1f, true);
        bool itemCheck_26 = CheckTolerance(TN5_VB_41, -1.0f, 0.1f, true);
        bool itemCheck_27 = CheckTolerance(TN5_VB_61, -1.0f, 0.1f, true);
        bool itemCheck_28 = CheckTolerance(TN5_VB_42, -1.0f, 0.1f, true);
        bool itemCheck_29 = CheckTolerance(TN5_VB_22, -1.0f, 0.1f, true);
        bool itemCheck_30 = CheckTolerance(TN5_VB_02, -1.0f, 0.1f, true);


        bool itemCheck_31 = CheckTolerance(TN5_Jx, 1666.66f, 0.1f, false); //Fix cứng giá trị đúng
        bool itemCheck_32 = CheckTolerance(TN5_YB_Lt, 0.27f, 0.1f, false); //Fix cứng giá trị đúng
        bool itemCheck_33 = CheckTolerance(TN5_PhiA, 0.00135f, 0.1f, false); //Fix cứng giá trị đúng


        bool itemCheck_34 = CheckTolerance(TN5_DVB_Tb, value_DVB, 0.1f, false);
        bool itemCheck_35 = CheckTolerance(TN5_DVD_Tb, value_DVD, 0.1f, false);

        bool itemCheck_36 = CheckTolerance(TN5_YB_Tt, value_DVB/100, 0.1f, false);
        bool itemCheck_37 = CheckTolerance(TN5_DphiA_Tt, value_DVD/100/103, 0.1f, false);

        //Kiem tra comment
        bool itemCheck_38 = CheckTolerance(TN5_Comments, -1.0f, 0.1f, true);//Only Check empty
        //CheckTolerance(TN2_purpose, value_DV, 0.1f, true);


        bool itemCheckTotal = false;
        if (
            itemCheck_1 && itemCheck_2 && itemCheck_3 &&
            itemCheck_4 && itemCheck_5 && itemCheck_6 &&
            itemCheck_7 && itemCheck_8 && itemCheck_9 &&
            itemCheck_10 && itemCheck_11 && itemCheck_12 &&
            itemCheck_13 && itemCheck_14 && itemCheck_15 &&
            itemCheck_16 && itemCheck_17 && itemCheck_18 &&
            itemCheck_19 && itemCheck_20 && itemCheck_21 &&
            itemCheck_22 && itemCheck_22 && itemCheck_24 &&
            itemCheck_25 && itemCheck_26 && itemCheck_27 &&
            itemCheck_28 && itemCheck_29 && itemCheck_30 &&
            itemCheck_31 && itemCheck_32 && itemCheck_33 &&
            itemCheck_34 && itemCheck_35 && itemCheck_36 &&
            itemCheck_37 && itemCheck_38)
        {
            itemCheckTotal = true;
        }

        //Ket qua can so
  //      float a1 = float.Parse(TN5_YB_Tt.text);
		//float b1 = 0.27f;

		//float tol1 = Mathf.Abs ((a1 - b1) / b1);
		//TN5_Tol1.text = Mathf.Round(tol1*100f).ToString ();


		//float a2 = float.Parse(TN5_DphiA_Tt.text);
		//float b2 = 0.139f;
		//float tol2 = Mathf.Abs ((a2 - b2) / b2);
		//TN5_Tol2.text = Mathf.Round(tol2*100f).ToString ();

		//float tol = Mathf.Max (tol1, tol2);

		if (itemCheckTotal) {

            warningWindow.gameObject.SetActive(false);
            exportPDFWindow.gameObject.SetActive(true);


            float a1 = float.Parse(TN5_YB_Tt.text);
            float b1 = 0.27f;

            float tol1 = Mathf.Abs((a1 - b1) / b1);
            TN5_Tol1.text = Mathf.Round(tol1 * 100f).ToString();


            float a2 = float.Parse(TN5_DphiA_Tt.text);
            float b2 = 0.00135f;
            float tol2 = Mathf.Abs((a2 - b2) / b2);
            TN5_Tol2.text = Mathf.Round(tol2 * 100f).ToString();

            float tol = Mathf.Max(tol1, tol2);


            TN5_Check.text = @"ÑAÏT";
			foreach (var myField in this.GetType().GetFields()) {

				string myNameObject = myField.Name;

				foreach (InputField gameObj in GameObject.FindObjectsOfType<InputField>()) {

					//if (gameObj.name == myNameObject) {

					//	if (gameObj.text == "" || gameObj.text == null) {
					//		myDicOut.Add (gameObj.name, "{" + gameObj.name + "}");
					//	} else {
					//		myDicOut.Add (gameObj.name, gameObj.text);
					//	}

					//}
				}
			}
			print (myDicOut.Keys.Count);
            myDicOut.Add("TN5_Timer", timer.text);

            //Clear text
            File.WriteAllText (pathOutPutFile, string.Empty);

			using (StreamWriter file = new StreamWriter (pathOutPutFile)) {
				foreach (string myKey in myDicOut.Keys) {
				
					string myStringToLine = "{" + myKey + "}" + "|" + myDicOut [myKey] + "\n";

					file.WriteLine (myStringToLine);
				}

			}


            ////ExportFiles
            ////will open from the applications dataPath directory
            //print (txtFile + " " + templateFile + " " + tenSinhVien);

            //System.Diagnostics.Process.Start ("ModifyPdf.exe",
            //	txtFile + " " + templateFile + " " + tenSinhVien);


            //ScreenShot
            if (cloneReport != null)
            {
                foreach (Transform child in cloneReport.transform)
                {
                    InputField tempInputField = child.GetComponent<InputField>();

                    if (tempInputField != null)
                    {
                        string nameOfField = tempInputField.name;
                        if (originReport != null)
                        {
                            foreach (Transform childOrigin in originReport.transform)
                            {
                                InputField tempInputFieldOrigin = childOrigin.GetComponent<InputField>();
                                if (tempInputFieldOrigin != null)
                                {
                                    if (tempInputFieldOrigin.name == nameOfField)
                                    {
                                        tempInputField.text = tempInputFieldOrigin.text;
                                    }
                                }
                            }
                        }
                    }
                }

                screenShotCam.gameObject.SetActive(true);

                RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);

                screenShotCam.targetTexture = rt;
                Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
                screenShotCam.Render();
                RenderTexture.active = rt;
                screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
                screenShotCam.targetTexture = null;
                RenderTexture.active = null;
                Destroy(rt);
                byte[] bytes = screenShot.EncodeToPNG();

                // Save file

                string pathSave = StandaloneFileBrowser.SaveFilePanel("Save File", "", "", "png");

                try
                {
                    System.IO.File.WriteAllBytes(pathSave, bytes);
                    Debug.Log(string.Format("Took screenshot to: {0}", pathSave));
                    screenShotCam.gameObject.SetActive(false);
                }
                catch
                {

                }
            }



        }
        else {
			TN5_Check.text = "KHOÂNG ÑAÏT";
            warningWindow.gameObject.SetActive(true);
            exportPDFWindow.gameObject.SetActive(false);
        }


        //For Test
        //if (cloneReport != null)
        //{
        //    foreach (Transform child in cloneReport.transform)
        //    {
        //        InputField tempInputField = child.GetComponent<InputField>();

        //        if (tempInputField != null)
        //        {
        //            string nameOfField = tempInputField.name;
        //            if (originReport != null)
        //            {
        //                foreach (Transform childOrigin in originReport.transform)
        //                {
        //                    InputField tempInputFieldOrigin = childOrigin.GetComponent<InputField>();
        //                    if (tempInputFieldOrigin != null)
        //                    {
        //                        if (tempInputFieldOrigin.name == nameOfField)
        //                        {
        //                            tempInputField.text = tempInputFieldOrigin.text;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    screenShotCam.gameObject.SetActive(true);

        //    RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);

        //    screenShotCam.targetTexture = rt;
        //    Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        //    screenShotCam.Render();
        //    RenderTexture.active = rt;
        //    screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        //    screenShotCam.targetTexture = null;
        //    RenderTexture.active = null;
        //    Destroy(rt);
        //    byte[] bytes = screenShot.EncodeToPNG();

        //    // Save file

        //    string pathSave = StandaloneFileBrowser.SaveFilePanel("Save File", "", "", "png");

        //    try
        //    {
        //        System.IO.File.WriteAllBytes(pathSave, bytes);
        //        Debug.Log(string.Format("Took screenshot to: {0}", pathSave));
        //        screenShotCam.gameObject.SetActive(false);
        //    }
        //    catch
        //    {

        //    }
        //}


    }

    public bool CheckTolerance(InputField inputField, float correctValue, float tolerance, bool dontCheckValue = false)
    {
        //Kiem tra cac o nhap lieu co trong ko?
        if (dontCheckValue)
        {
            if (string.IsNullOrEmpty(inputField.text))
            {
                inputField.image.color = Color.yellow;
                return false;
            }
            else
            {
                inputField.image.color = Color.white;
                return true;
            }
        }

        else
        {
            //Kiem tra sai so va boi do field
            if (string.IsNullOrEmpty(inputField.text))
            {
                inputField.image.color = Color.yellow;
                return false;
            }
            float inputValue = float.Parse(inputField.text);
            float tol = Mathf.Abs((inputValue - correctValue) / correctValue);
            if (tol > tolerance)
            {
                inputField.image.color = Color.yellow;
                return false;
            }
            else
            {
                inputField.image.color = Color.white;
                return true;
            }
        }
        return false;
    }

}
