using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SaveInputValueToTextTN4 : MonoBehaviour {
	public string nameOutPutFile = @"Templates\OutPut_TN4.txt";

	public string txtFile = "";
	public string templateFile = "";
	public string tenSinhVien = "";


	public InputField TN4_Check;
	public InputField TN4_Tol;


	public InputField TN4_l;
	public InputField TN4_b;
	public InputField TN4_h;

	public InputField TN4_Vt_01;
	public InputField TN4_Vt_21;
	public InputField TN4_Vt_41;
	public InputField TN4_Vt_61;
	public InputField TN4_Vt_42;
	public InputField TN4_Vt_22;
	public InputField TN4_Vt_02;

	public InputField TN4_DVt_02;
	public InputField TN4_DVt_24;
	public InputField TN4_DVt_46;
	public InputField TN4_DVt_64;
	public InputField TN4_DVt_42;
	public InputField TN4_DVt_20;

	public InputField TN4_Vd_01;
	public InputField TN4_Vd_21;
	public InputField TN4_Vd_41;
	public InputField TN4_Vd_61;
	public InputField TN4_Vd_42;
	public InputField TN4_Vd_22;
	public InputField TN4_Vd_02;

	public InputField TN4_DVd_02;
	public InputField TN4_DVd_24;
	public InputField TN4_DVd_46;
	public InputField TN4_DVd_64;
	public InputField TN4_DVd_42;
	public InputField TN4_DVd_20;

	public InputField TN4_Wx;
	public InputField TN4_DMx;
	public InputField TN4_Sig_mima;
	public InputField TN4_DVt_tb;
	public InputField TN4_DVd_tb;

	public InputField TN4_Ep_t_tb;
	public InputField TN4_Ep_d_tb;
	public InputField TN4_Sig_max;
	public InputField TN4_Sig_min;

	public InputField TN4_Comments;

	public GameObject warningWindow;
    public GameObject exportPDFWindow;

    //Canbe Check if begin TN4
    public Text timer;


    public void SaveDataToText() {

        warningWindow.gameObject.SetActive(false);
        exportPDFWindow.gameObject.SetActive(false);

        Dictionary<string, string> myDicOut = new Dictionary<string, string> ();

		string currentFolder = Directory.GetCurrentDirectory ();

		string pathOutPutFile = Path.Combine (currentFolder, nameOutPutFile);


        //Kiem tra so lieu tinh

        float value_l = -1f;

        try
        {
            value_l = float.Parse(TN4_l.text); //L thay doi
        }
        catch
        {

        }

        float value_DMx = 2*value_l; //deltaMx = delta_P*l
        float value_Sig_mima = value_DMx/120.0f; // theo cong thuc = Dmx/Wx
        float value_Ep_tb = value_Sig_mima / 20000f; //theo cong thuc: ep = sig/E (E=20000)
        float value_DV_tb = value_Ep_tb * 20 * 1000; //Theo cong thuc Dvt = ep*a*k (k=1000, a = 20mm)

        //Kiem tra ket qua tinh voi sai so <10%

        bool itemCheck_1 = CheckTolerance(TN4_l, -1.0f, 0.15f, true); //L thay doi, khong check dau vao
        bool itemCheck_2 = CheckTolerance(TN4_b, 20f, 0.15f);
        bool itemCheck_3 = CheckTolerance(TN4_h, 6f, 0.15f);

        bool itemCheck_4 = CheckTolerance(TN4_DVt_02, value_DV_tb, 0.35f);
        bool itemCheck_5 = CheckTolerance(TN4_DVt_24, value_DV_tb, 0.35f);
        bool itemCheck_6 = CheckTolerance(TN4_DVt_46, value_DV_tb, 0.35f);
        bool itemCheck_7 = CheckTolerance(TN4_DVt_64, value_DV_tb, 0.35f);
        bool itemCheck_8 = CheckTolerance(TN4_DVt_42, value_DV_tb, 0.35f);
        bool itemCheck_9 = CheckTolerance(TN4_DVt_20, value_DV_tb, 0.35f);

        bool itemCheck_10 = CheckTolerance(TN4_DVd_02, value_DV_tb, 0.35f);
        bool itemCheck_11 = CheckTolerance(TN4_DVd_24, value_DV_tb, 0.35f);
        bool itemCheck_12 = CheckTolerance(TN4_DVd_46, value_DV_tb, 0.35f);
        bool itemCheck_13 = CheckTolerance(TN4_DVd_64, value_DV_tb, 0.35f);
        bool itemCheck_14 = CheckTolerance(TN4_DVd_42, value_DV_tb, 0.35f);
        bool itemCheck_15 = CheckTolerance(TN4_DVd_20, value_DV_tb, 0.35f);


        bool itemCheck_16 = CheckTolerance(TN4_Wx, 120.0f, 0.15f); //Gia tri khong doi = bh^2/6
        bool itemCheck_17 = CheckTolerance(TN4_DMx, value_DMx, 0.15f);
        bool itemCheck_18 = CheckTolerance(TN4_Sig_mima, value_Sig_mima, 0.35f); 
        bool itemCheck_19 = CheckTolerance(TN4_DVt_tb, value_DV_tb, 0.20f);
        bool itemCheck_20 = CheckTolerance(TN4_DVd_tb, value_DV_tb, 0.20f);

        bool itemCheck_21 = CheckTolerance(TN4_Ep_t_tb, value_Ep_tb, 0.25f);
        bool itemCheck_22 = CheckTolerance(TN4_Ep_d_tb, value_Ep_tb, 0.25f); 


        bool itemCheck_23 = CheckTolerance(TN4_Sig_max, value_Sig_mima, 0.15f); //TN4_Sig_max
        bool itemCheck_24 = CheckTolerance(TN4_Sig_min, value_Sig_mima, 0.15f); //TN4_Sig_min

        //Kiem tra cac o khong can check value chi can check empty
        bool itemCheck_25 = CheckTolerance(TN4_Vt_01, 1, 0.1f, true);
        bool itemCheck_26 = CheckTolerance(TN4_Vt_21, 1, 0.1f, true);
        bool itemCheck_27 = CheckTolerance(TN4_Vt_41, 1, 0.1f, true);
        bool itemCheck_28 = CheckTolerance(TN4_Vt_61, 1, 0.1f, true);
        bool itemCheck_29 = CheckTolerance(TN4_Vt_42, 1, 0.1f, true);
        bool itemCheck_30 = CheckTolerance(TN4_Vt_22, 1, 0.1f, true);
        bool itemCheck_31 = CheckTolerance(TN4_Vt_02, 1, 0.1f, true);

        bool itemCheck_32 = CheckTolerance(TN4_Vd_01, 1, 0.1f, true);
        bool itemCheck_33 = CheckTolerance(TN4_Vd_21, 1, 0.1f, true);
        bool itemCheck_34 = CheckTolerance(TN4_Vd_41, 1, 0.1f, true);
        bool itemCheck_35 = CheckTolerance(TN4_Vd_61, 1, 0.1f, true);
        bool itemCheck_36 = CheckTolerance(TN4_Vd_42, 1, 0.1f, true);
        bool itemCheck_37 = CheckTolerance(TN4_Vd_22, 1, 0.1f, true);
        bool itemCheck_38 = CheckTolerance(TN4_Vd_02, 1, 0.1f, true);



        //Kiem tra comment
        bool itemCheck_39 = CheckTolerance(TN4_Comments, -1.0f, 0.1f, true);//Only Check empty
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
            itemCheck_37 && itemCheck_38 && itemCheck_39)
        {
            itemCheckTotal = true;
        }


        //Ket qua can so
        //      float a = float.Parse(TN3_G_Tt.text);
        //float b = 8000f;

        //float tol = Mathf.Abs ((a - b) / b);

        //TN3_Tol.text = Mathf.Round(tol*100f).ToString ();




  //      //Ket qua can so
  //      float a = float.Parse (TN4_Sig_min.text);
		//float a2 = float.Parse (TN4_Sig_max.text);
		//float b = 25f;
		//float tol = Mathf.Max(Mathf.Abs ((a - b) / b), Mathf.Abs ((a2 - b) / b));
		//TN4_Tol.text = Mathf.Round(tol*100f).ToString ();


		if (itemCheckTotal) {

            warningWindow.gameObject.SetActive(false);
            exportPDFWindow.gameObject.SetActive(true);

            float a = float.Parse(TN4_Sig_min.text);
            float a2 = float.Parse(TN4_Sig_max.text);
            float b = value_Sig_mima;
            float tol = Mathf.Max(Mathf.Abs((a - b) / b), Mathf.Abs((a2 - b) / b));
            TN4_Tol.text = Mathf.Round(tol * 100f).ToString();

            TN4_Check.text = @"ÑAÏT";

			foreach (var myField in this.GetType().GetFields()) {

				string myNameObject = myField.Name;

				foreach (InputField gameObj in GameObject.FindObjectsOfType<InputField>()) {

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
            myDicOut.Add("TN4_Timer", timer.text);

            //Clear text
            File.WriteAllText (pathOutPutFile, string.Empty);

			using (StreamWriter file = new StreamWriter (pathOutPutFile)) {
				foreach (string myKey in myDicOut.Keys) {
				
					string myStringToLine = "{" + myKey + "}" + "|" + myDicOut [myKey] + "\n";

					file.WriteLine (myStringToLine);
				}

			}


			//ExportFiles
			//will open from the applications dataPath directory
			System.Diagnostics.Process.Start ("ModifyPdf.exe",
				txtFile + " " + templateFile + " " + tenSinhVien);


		} else {

			TN4_Check.text = "KHOÂNG ÑAÏT";
            warningWindow.gameObject.SetActive(true);
            exportPDFWindow.gameObject.SetActive(false);
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
