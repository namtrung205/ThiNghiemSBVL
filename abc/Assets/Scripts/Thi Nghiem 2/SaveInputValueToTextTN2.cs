using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using SFB;

public class SaveInputValueToTextTN2 : MonoBehaviour {
	public string nameOutPutFile = @"Templates\OutPut_TN2.txt";

    public int resWidth = 2550;
    public int resHeight = 3300;
    public Camera screenShotCam;

    public GameObject originReport;
    public GameObject cloneReport;


    public string txtFile = "";
	public string templateFile = "";
	public string tenSinhVien = "";

	public InputField TN2_Check;
	public InputField TN2_Tol;

	public InputField TN2_a;
	public InputField TN2_d;

	public InputField TN2_VT_01;
	public InputField TN2_VT_31;
	public InputField TN2_VT_61;
	public InputField TN2_VT_91;
	public InputField TN2_VT_62;
	public InputField TN2_VT_32;
	public InputField TN2_VT_02;


	public InputField TN2_DVT_03;
	public InputField TN2_DVT_36;
	public InputField TN2_DVT_69;
	public InputField TN2_DVT_96;
	public InputField TN2_DVT_63;
	public InputField TN2_DVT_30;

	public InputField TN2_VP_01;
	public InputField TN2_VP_31;
	public InputField TN2_VP_61;
	public InputField TN2_VP_91;
	public InputField TN2_VP_62;
	public InputField TN2_VP_32;
	public InputField TN2_VP_02;


	public InputField TN2_DVP_03;
	public InputField TN2_DVP_36;
	public InputField TN2_DVP_69;
	public InputField TN2_DVP_96;
	public InputField TN2_DVP_63;
	public InputField TN2_DVP_30;

	public InputField TN2_DVT_tb;
	public InputField TN2_DVP_tb;

	public InputField TN2_DaT;
	public InputField TN2_DaP;

	public InputField TN2_ep_tb;
	public InputField TN2_del;
	public InputField TN2_E;

	public InputField TN2_Comment;
	public InputField TN2_purpose;

	public GameObject warningWindow;
    public GameObject exportPDFWindow;

    public Text timer;

	//Canbe Check if begin TN1

	public void SaveDataToText() {

        warningWindow.gameObject.SetActive(false);
        exportPDFWindow.gameObject.SetActive(false);

        Dictionary<string, string> myDicOut = new Dictionary<string, string> ();

		string currentFolder = Directory.GetCurrentDirectory ();

		string pathOutPutFile = Path.Combine (currentFolder, nameOutPutFile);

        //Kiem tra so lieu tinh
        float value_d = 10f; //Chi so vach moi lan tang 1 cap tai
        float value_DV = 3.8f; //Chi so vach moi lan tang 1 cap tai
        float value_Da = value_DV/100; //Chi so bien dang lan tang 1 cap tai DV/K (K=100)
        float value_eP = value_Da / 200; //Chi so bien dang lan tang 1 cap tai da/a (a=200)
        float value_de = 300f/ 78.54f; //ung suat trong thanh (delta P/F, F = 5^2*PI, delta P = 300kG)
        float value_E = 20000f; //ung suat trong thanh (delta P/F, F = 5^2*PI, delta P = 300kG)

        bool itemCheck_1 = CheckTolerance(TN2_d, value_d, 0.1f);
        bool itemCheck_2 = CheckTolerance(TN2_DVT_03, value_DV, 0.15f);
        bool itemCheck_3 = CheckTolerance(TN2_DVT_36, value_DV, 0.15f);
        bool itemCheck_4 = CheckTolerance(TN2_DVT_69, value_DV, 0.15f);
        bool itemCheck_5 = CheckTolerance(TN2_DVT_96, value_DV, 0.15f);
        bool itemCheck_6 = CheckTolerance(TN2_DVT_63, value_DV, 0.15f);
        bool itemCheck_7 = CheckTolerance(TN2_DVT_30, value_DV, 0.15f);
        bool itemCheck_8 = CheckTolerance(TN2_DVP_03, value_DV, 0.15f);
        bool itemCheck_9 = CheckTolerance(TN2_DVP_36, value_DV, 0.15f);
        bool itemCheck_10 = CheckTolerance(TN2_DVP_69, value_DV, 0.15f);
        bool itemCheck_11 = CheckTolerance(TN2_DVP_96, value_DV, 0.15f);
        bool itemCheck_12 = CheckTolerance(TN2_DVP_63, value_DV, 0.15f);
        bool itemCheck_13 = CheckTolerance(TN2_DVP_30, value_DV, 0.15f);

        //Kiem tra cac o khong can check value chi can check empty

        bool itemCheck_14 = CheckTolerance(TN2_VT_01, value_DV, 0.1f, true);
        bool itemCheck_15 = CheckTolerance(TN2_VT_31, value_DV, 0.1f, true);
        bool itemCheck_16 = CheckTolerance(TN2_VT_61, value_DV, 0.1f, true);
        bool itemCheck_17 = CheckTolerance(TN2_VT_91, value_DV, 0.1f, true);
        bool itemCheck_18 = CheckTolerance(TN2_VT_62, value_DV, 0.1f, true);
        bool itemCheck_19 = CheckTolerance(TN2_VT_32, value_DV, 0.1f, true);
        bool itemCheck_20 = CheckTolerance(TN2_VT_02, value_DV, 0.1f, true);

        bool itemCheck_21 = CheckTolerance(TN2_VP_01, value_DV, 0.1f, true);
        bool itemCheck_22 = CheckTolerance(TN2_VP_31, value_DV, 0.1f, true);
        bool itemCheck_23 = CheckTolerance(TN2_VP_61, value_DV, 0.1f, true);
        bool itemCheck_24 = CheckTolerance(TN2_VP_91, value_DV, 0.1f, true);
        bool itemCheck_25 = CheckTolerance(TN2_VP_62, value_DV, 0.1f, true);
        bool itemCheck_26 = CheckTolerance(TN2_VP_32, value_DV, 0.1f, true);
        bool itemCheck_27 = CheckTolerance(TN2_VP_02, value_DV, 0.1f, true);

        //Kiem tra ket qua tinh voi sai so <10%

        bool itemCheck_28 = CheckTolerance(TN2_DVT_tb, value_DV, 0.1f, false);
        bool itemCheck_29 = CheckTolerance(TN2_DVP_tb, value_DV, 0.1f, false);

        bool itemCheck_30 = CheckTolerance(TN2_DaT, value_Da, 0.1f, false);
        bool itemCheck_31 = CheckTolerance(TN2_DaP, value_Da, 0.1f, false);

        bool itemCheck_32 = CheckTolerance(TN2_ep_tb, value_eP, 0.1f, false);
        bool itemCheck_33 = CheckTolerance(TN2_del, value_de, 0.1f, false);
        bool itemCheck_34 = CheckTolerance(TN2_E, value_E, 0.1f, false);

        bool itemCheck_35 = CheckTolerance(TN2_Comment, value_DV, 0.1f, true);
        //CheckTolerance(TN2_purpose, value_DV, 0.1f, true);


        bool itemCheckTotal = false;
        if(
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
            itemCheck_34 && itemCheck_35)
        {
            itemCheckTotal = true;
        }

        //Ket qua can so
        float a;
        bool try_a = float.TryParse(TN2_E.text, out a);
		float b = 20000f;
        float tol = 1;
        if (try_a)
        {
            tol = Mathf.Abs((a - b) / b);
            TN2_Tol.text = Mathf.Round(tol * 100f).ToString();
        }

		if (itemCheckTotal) {

            warningWindow.gameObject.SetActive(false);
            exportPDFWindow.gameObject.SetActive(true);


            TN2_Check.text = @"ÑAÏT";

			foreach (var myField in this.GetType().GetFields()) {

				string myNameObject = myField.Name;

				foreach (InputField gameObj in GameObject.FindObjectsOfType<InputField>()) 
				{

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
            myDicOut.Add("TN2_Timer", timer.text);

			//Clear text
			File.WriteAllText(pathOutPutFile, string.Empty);

			using (StreamWriter file = new StreamWriter (pathOutPutFile)) 
			{
				foreach (string myKey in myDicOut.Keys) {

					string myStringToLine = "{" + myKey + "}" + "|" + myDicOut [myKey]+"\n";

					file.WriteLine (myStringToLine);
				}
			}

            ////ExportFiles
            ////will open from the applications dataPath directory
            //System.Diagnostics.Process.Start("ModifyPdf.exe",
            //	txtFile+ " " + templateFile+ " " + tenSinhVien);

            //screenShoot and save
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
        else
        {
			TN2_Check.text = "KHOÂNG ÑAÏT";
            warningWindow.gameObject.SetActive(true);
            exportPDFWindow.gameObject.SetActive(false);
        }

        //for test
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

        //    var pathSave = StandaloneFileBrowser.SaveFilePanel("Save File", "", "", "png");

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
        if(dontCheckValue)
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
