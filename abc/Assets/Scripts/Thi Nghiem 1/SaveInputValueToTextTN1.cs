using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SaveInputValueToTextTN1 : MonoBehaviour {

	public string nameOutPutFile = @"Templates\OutPut_TN1.txt";

	public string txtFile = "";
	public string templateFile = "";
	public string tenSinhVien = "";


	public InputField TN1_d0;
	public InputField TN1_l0;
	public InputField TN1_F0;
	public InputField TN1_d1;
	public InputField TN1_dPh;
	public InputField TN1_FPh;

	public InputField TN1_F1;
	public InputField TN1_l1;
	public InputField TN1_DeL;
	public InputField TN1_Sig_tl;

	public InputField TN1_Sig_b;

	public InputField TN1_Sig_ch;
	public InputField TN1_Sig_ph;
	public InputField TN1_Delta;
	public InputField TN1_Psi;

	public InputField TN1_Comment;
    //	public InputField TN1_purpose;



    public Text timer;

    public Image sourceImage;

    //Canbe Check if begin TN1
    public GameObject warningWindow;
    public GameObject exportPDFWindow;


    public void SaveDataToText() {

        warningWindow.gameObject.SetActive(false);
        exportPDFWindow.gameObject.SetActive(false);

        Dictionary<string, string> myDicOut = new Dictionary<string, string> ();

		string currentFolder = Directory.GetCurrentDirectory ();

		string pathOutPutFile = Path.Combine (currentFolder, nameOutPutFile);

        //Kiem tra so lieu tinh
        float value_d0 = 10f; //Duong kinh mau
        float value_F0 = 3.14f * (10f * 10f)/4; //Chi so bien dang lan tang 1 cap tai DV/K (K=100)
        float value_l0 = 100f; //Chieu Dai Ban Dau

        float value_d1 = 9.0f; //Duong kinh mau
        float value_F1 = 3.14f * (9f * 9f)/4; //Chi so bien dang lan tang 1 cap tai DV/K (K=100)
        float value_l1 = 123.0f; //Chieu Dai Ban Dau    

        float value_dPh = 6.5f; //Duong kinh mau
        float value_FPh = 3.14f * (6.5f*6.5f)/4; //Chi so bien dang lan tang 1 cap tai DV/K (K=100)
        float value_DelL = 23.0f; //Chieu Dai Ban Dau  

        bool itemCheck_1 = CheckTolerance(TN1_d0, value_d0, 0.15f, false);
        bool itemCheck_2 = CheckTolerance(TN1_l0, value_l0, 0.15f, false);
        bool itemCheck_3 = CheckTolerance(TN1_F0, value_F0, 0.15f, false);
        bool itemCheck_4 = CheckTolerance(TN1_d1, value_d1, 0.15f, false);
        bool itemCheck_5 = CheckTolerance(TN1_dPh, value_dPh, 0.15f, false);
        bool itemCheck_6 = CheckTolerance(TN1_FPh, value_FPh, 0.15f, false);
        bool itemCheck_7 = CheckTolerance(TN1_F1, value_F1, 0.15f, false);
        bool itemCheck_8 = CheckTolerance(TN1_l1, value_l1, 0.15f, false);
        bool itemCheck_9 = CheckTolerance(TN1_DeL, value_DelL, 0.15f, false);
        bool itemCheck_10 = CheckTolerance(TN1_Sig_tl, +22000/ value_F0, 0.30f, false); //Lay tb 22000
        bool itemCheck_11 = CheckTolerance(TN1_Sig_ch, +26500f/ value_F0, 0.30f, false); //Lay tb 26500
        bool itemCheck_12 = CheckTolerance(TN1_Sig_b, +38700f / value_F0, 0.30f, false); //Lay tb 38700f
        bool itemCheck_13 = CheckTolerance(TN1_Sig_ph, +29200f / value_FPh, 0.30f, false); //Lay tb 29200f
        bool itemCheck_14 = CheckTolerance(TN1_Delta, 23.0f, 0.20f, false);
        bool itemCheck_15 = CheckTolerance(TN1_Psi, 20f, 0.30f, false);
        bool itemCheck_16 = CheckTolerance(TN1_Comment, -1f, 0.20f, true);

        foreach (var myField in this.GetType().GetFields()) {

			string myNameObject = myField.Name;

			foreach (InputField gameObj in GameObject.FindObjectsOfType<InputField>()) 
			{

				if (gameObj.name == myNameObject) {

					if (gameObj.text == "" || gameObj.text == null) {
						myDicOut.Add (gameObj.name, "{" + gameObj.name + "}");
					} else {
						myDicOut.Add (gameObj.name, gameObj.text);
					}

				}
			}

		}
		print (myDicOut.Keys.Count);
        myDicOut.Add("TN1_Timer", timer.text);


        //Clear text
        File.WriteAllText(pathOutPutFile, string.Empty);

		using (StreamWriter file = new StreamWriter (pathOutPutFile)) 
		{
			foreach (string myKey in myDicOut.Keys) {

				string myStringToLine = "{" + myKey + "}" + "|" + myDicOut [myKey]+"\n";

				file.WriteLine (myStringToLine);
			}

		}
        if (sourceImage != null)
        {
            if (sourceImage.overrideSprite!=null)
            {
                print(sourceImage.overrideSprite.name);
            }
            else
            {
                warningWindow.gameObject.SetActive(true);
            }
        }
        else
        {
            warningWindow.gameObject.SetActive(true);
        }


//		string pathImage = Path.Combine (currentFolder, "Templates/"+sourceImage.sprite.name+".png");
		string pathImage = @"Templates\"+sourceImage.overrideSprite.name+".png";

		print (pathImage);
        //ExportFiles

        //check
        bool itemCheckTotal = false;
        if (
            itemCheck_1 && itemCheck_2 && itemCheck_3 &&
            itemCheck_4 && itemCheck_5 && itemCheck_6 &&
            itemCheck_7 && itemCheck_8 && itemCheck_9 &&
            itemCheck_10 && itemCheck_11 && itemCheck_12 &&
            itemCheck_13 && itemCheck_14 && itemCheck_15 &&
            itemCheck_16)
        {
            itemCheckTotal = true;
        }

        if (itemCheckTotal)
        {
            exportPDFWindow.gameObject.SetActive(true);
            //will open from the applications dataPath directory
            System.Diagnostics.Process.Start("ModifyPdf.exe",
                txtFile + " " + templateFile + " " + tenSinhVien + " " + pathImage);
        }
        else
        {
            warningWindow.gameObject.SetActive(true);
        }

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
