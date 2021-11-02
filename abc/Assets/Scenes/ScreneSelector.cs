using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class ScreneSelector : MonoBehaviour {
	public string nameOutPutFile = @"Templates\OutPut_User.txt";
    public InputField TenGiaoVien;
    public InputField Lop;
    public InputField Nhom;
    public InputField TenSinhVien;

    public GameObject warningWindow;
    public GameObject warningWindowExpired;

    public Text RemainingDaysText;

    private bool allowFromInternet = false;

    public void selectScene(){

        //if (checkExpriedDate()) 
        if (checkInputInfor()) {
            warningWindow.SetActive(true);
            print("Chua nhap ten");
        }
        else
        {
			//Save Data
			Dictionary<string, string> myDicOut = new Dictionary<string, string> ();

			string currentFolder = Directory.GetCurrentDirectory ();

			string pathOutPutFile = Path.Combine (currentFolder, nameOutPutFile);

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




			//Clear text
			File.WriteAllText(pathOutPutFile, string.Empty);

			using (StreamWriter file = new StreamWriter (pathOutPutFile)) 
			{
				foreach (string myKey in myDicOut.Keys) {

					string myStringToLine = "{" + myKey + "}" + "|" + myDicOut [myKey]+"\n";

					file.WriteLine (myStringToLine);
				}

			}


            switch (this.gameObject.name)
            {
                case "TN1_Thumbnail":
                    SceneManager.LoadScene("TN1_3D");
                    break;

                case "TN2_Thumbnail":
                    SceneManager.LoadScene("TN2_3D");
                    break;

                case "TN3_Thumbnail":
                    SceneManager.LoadScene("TN3_3D");
                    break;

                case "TN4_Thumbnail":
                    SceneManager.LoadScene("TN4_3D");
                    break;

                case "TN5_Thumbnail":
                    SceneManager.LoadScene("TN5_3D");
                    break;

            }


		}
	}

    public bool checkInputInfor()
    {
        if (TenGiaoVien.text.ToString() == "" || Lop.text.ToString() == "" || Nhom.text.ToString() == "" || TenSinhVien.text.ToString() == "")
        {
            return true;
        }

        return false;
    }

    public bool checkExpriedDate()
    {
        if (RemainingDaysText != null)
        {
            int iRemainingDays = System.Convert.ToInt32(RemainingDaysText.text);
            if(iRemainingDays < 1) 
            {
                return true;
            }
        }

        return false;
    }


    public bool checkAllowFromInternet() 
    {
        string url = "https://textuploader.com/t5sbh/raw";
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));

        return allowFromInternet;
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        // check for errors
        if (www.error == null)
        {
            if (!www.text.Contains("SBVL@2021"))
            {
                allowFromInternet = false;
            }
            else
            {
                allowFromInternet = true;
            }
        }
        else
        {
            allowFromInternet = false;
        }
    }

}
