using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SaveInputValueToTextTN3 : MonoBehaviour {
	public string nameOutPutFile = @"Templates\OutPut_TN3.txt";

	public string txtFile = "";
	public string templateFile = "";
	public string tenSinhVien = "";

	public InputField TN3_Check;
	public InputField TN3_Tol;

	public InputField TN3_l;
	public InputField TN3_d;
	public InputField TN3_D;
	public InputField TN3_a;
	public InputField TN3_bM;
	public InputField TN3_bN;

	public InputField TN3_VM_01;
	public InputField TN3_VM_21;
	public InputField TN3_VM_41;
	public InputField TN3_VM_61;
	public InputField TN3_VM_42;
	public InputField TN3_VM_22;
	public InputField TN3_VM_02;


	public InputField TN3_DVM_02;
	public InputField TN3_DVM_24;
	public InputField TN3_DVM_46;
	public InputField TN3_DVM_64;
	public InputField TN3_DVM_42;
	public InputField TN3_DVM_20;

	public InputField TN3_VN_01;
	public InputField TN3_VN_21;
	public InputField TN3_VN_41;
	public InputField TN3_VN_61;
	public InputField TN3_VN_42;
	public InputField TN3_VN_22;
	public InputField TN3_VN_02;


	public InputField TN3_DVN_02;
	public InputField TN3_DVN_24;
	public InputField TN3_DVN_46;
	public InputField TN3_DVN_64;
	public InputField TN3_DVN_42;
	public InputField TN3_DVN_20;

	public InputField TN3_G_Lt;
	public InputField TN3_J0;
	public InputField TN3_DMz;
	public InputField TN3_DVM_Tb;
	public InputField TN3_DVN_Tb;

	public InputField TN3_PhiM;
	public InputField TN3_PhiN;
	public InputField TN3_DPhiM;
	public InputField TN3_G_Tt;

	public InputField TN3_Comment;

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
        float value_l = 250f; //Chi so vach moi lan tang 1 cap tai
        float value_d = 30f; //Chi so vach moi lan tang 1 cap tai
        float value_D = 32f; //Chi so vach moi lan tang 1 cap tai
        float value_a = 108.5f; //Chi so vach moi lan tang 1 cap tai
        float value_bM = 130.5f; //Chi so vach moi lan tang 1 cap tai
        float value_bN = 130.5f; //Chi so vach moi lan tang 1 cap tai
        float value_DVM = 18.53f; //Chi so vach moi lan tang 1 cap tai
        float value_DVN = 11.12f; //Chi so vach moi lan tang 1 cap tai
        float value_Da = value_DVM / 100; //Chi so bien dang lan tang 1 cap tai DV/K (K=100)
        float value_eP = value_Da / 200; //Chi so bien dang lan tang 1 cap tai da/a (a=200)
        float value_de = 300f / 78.54f; //ung suat trong thanh (delta P/F, F = 5^2*PI, delta P = 300kG)
        float value_E = 20000f; //ung suat trong thanh (delta P/F, F = 5^2*PI, delta P = 300kG)


        //Kiem tra ket qua tinh voi sai so <10%

        bool itemCheck_1 = CheckTolerance(TN3_l, 250f, 0.15f); //Fix cứng giá trị đúng
        bool itemCheck_2 = CheckTolerance(TN3_d, 30f, 0.15f);
        bool itemCheck_3 = CheckTolerance(TN3_D, 32f, 0.15f);
        bool itemCheck_4 = CheckTolerance(TN3_a, 108.5f, 0.15f);
        bool itemCheck_5 = CheckTolerance(TN3_bM, 130.5f, 0.15f);
        bool itemCheck_6 = CheckTolerance(TN3_bN, 130.5f, 0.15f);


        bool itemCheck_7 = CheckTolerance(TN3_DVM_02, value_DVM, 0.15f);
        bool itemCheck_8 = CheckTolerance(TN3_DVM_24, value_DVM, 0.15f);
        bool itemCheck_9 = CheckTolerance(TN3_DVM_46, value_DVM, 0.15f);
        bool itemCheck_10 = CheckTolerance(TN3_DVM_64, value_DVM, 0.15f);
        bool itemCheck_11 = CheckTolerance(TN3_DVM_42, value_DVM, 0.15f);
        bool itemCheck_12 = CheckTolerance(TN3_DVM_20, value_DVM, 0.15f);

        bool itemCheck_13 = CheckTolerance(TN3_DVN_02, value_DVN, 0.15f);
        bool itemCheck_14 = CheckTolerance(TN3_DVN_24, value_DVN, 0.15f);
        bool itemCheck_15 = CheckTolerance(TN3_DVN_46, value_DVN, 0.15f);
        bool itemCheck_16 = CheckTolerance(TN3_DVN_64, value_DVN, 0.15f);
        bool itemCheck_17 = CheckTolerance(TN3_DVN_42, value_DVN, 0.15f);
        bool itemCheck_18 = CheckTolerance(TN3_DVN_20, value_DVN, 0.15f);


        //Kiem tra cac o khong can check value chi can check empty
        bool itemCheck_19 = CheckTolerance(TN3_VM_01, value_DVM, 0.1f, true);
        bool itemCheck_20 = CheckTolerance(TN3_VM_21, value_DVM, 0.1f, true);
        bool itemCheck_21 = CheckTolerance(TN3_VM_41, value_DVM, 0.1f, true);
        bool itemCheck_22 = CheckTolerance(TN3_VM_61, value_DVM, 0.1f, true);
        bool itemCheck_23 = CheckTolerance(TN3_VM_42, value_DVM, 0.1f, true);
        bool itemCheck_24 = CheckTolerance(TN3_VM_22, value_DVM, 0.1f, true);
        bool itemCheck_25 = CheckTolerance(TN3_VM_02, value_DVM, 0.1f, true);

        bool itemCheck_26 = CheckTolerance(TN3_VN_01, value_DVN, 0.1f, true);
        bool itemCheck_27 = CheckTolerance(TN3_VN_21, value_DVN, 0.1f, true);
        bool itemCheck_28 = CheckTolerance(TN3_VN_41, value_DVN, 0.1f, true);
        bool itemCheck_29 = CheckTolerance(TN3_VN_61, value_DVN, 0.1f, true);
        bool itemCheck_30 = CheckTolerance(TN3_VN_42, value_DVN, 0.1f, true);
        bool itemCheck_31 = CheckTolerance(TN3_VN_22, value_DVN, 0.1f, true);
        bool itemCheck_32 = CheckTolerance(TN3_VN_02, value_DVN, 0.1f, true);

        //Kiem tra ket qua tinh voi sai so <10%
        bool itemCheck_33 = CheckTolerance(TN3_G_Lt, 8000f, 0.1f, false); //Fix cứng giá trị đúng
        bool itemCheck_34 = CheckTolerance(TN3_J0, 23857.60f, 0.1f, false); //Fix cứng giá trị đúng

        bool itemCheck_35 = CheckTolerance(TN3_DMz, 434.00f, 0.1f, false); //Fix cứng giá trị đúng
        bool itemCheck_36 = CheckTolerance(TN3_DVM_Tb, value_DVM, 0.1f, false);
        bool itemCheck_37 = CheckTolerance(TN3_DVN_Tb, value_DVN, 0.1f, false);

        bool itemCheck_38 = CheckTolerance(TN3_PhiM, 0.00142f, 0.1f, false);
        bool itemCheck_39 = CheckTolerance(TN3_PhiN, 0.000852f, 0.1f, false);
        bool itemCheck_40 = CheckTolerance(TN3_DPhiM, 0.000568f, 0.1f, false);
        bool itemCheck_41 = CheckTolerance(TN3_G_Tt, 8000, 0.1f, false);


        //Kiem tra comment
        bool itemCheck_42 = CheckTolerance(TN3_Comment, -1.0f, 0.1f, true);//Only Check empty
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
            itemCheck_34 && itemCheck_35 &&itemCheck_36 &&
            itemCheck_37 && itemCheck_38 &&itemCheck_39 && 
            itemCheck_40 && itemCheck_41 && itemCheck_42)
        {
            itemCheckTotal = true;
        }


        //Ket qua can so
  //      float a = float.Parse(TN3_G_Tt.text);
		//float b = 8000f;

		//float tol = Mathf.Abs ((a - b) / b);

		//TN3_Tol.text = Mathf.Round(tol*100f).ToString ();

		if (itemCheckTotal) {
            warningWindow.gameObject.SetActive(false);
            exportPDFWindow.gameObject.SetActive(true);

            float a = float.Parse(TN3_G_Tt.text);
            float b = 8000f;

            float tol = Mathf.Abs((a - b) / b);

            TN3_Tol.text = Mathf.Round(tol * 100f).ToString();

            TN3_Check.text = @"ÑAÏT";
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
            myDicOut.Add("TN3_Timer", timer.text);
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

			print (txtFile + " " + templateFile + " " + tenSinhVien);

			System.Diagnostics.Process.Start ("ModifyPdf.exe",
				txtFile + " " + templateFile + " " + tenSinhVien);

		} else {
			TN3_Check.text = "KHOÂNG ÑAÏT";
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
