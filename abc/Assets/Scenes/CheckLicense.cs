using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class CheckLicense : MonoBehaviour {

	public string nameInPutFile = @"Templates\OutPut_User.txt";
	public InputField TenGiaoVien;
	public InputField Lop;
	public InputField Nhom;
	public InputField TenSinhVien;


	void Start () {
		string url = "https://textuploader.com/tswig/raw";
		WWW www = new WWW(url);
        //StartCoroutine(WaitForRequest(www));

        //Load Data
        string currentFolder = Directory.GetCurrentDirectory ();

		string pathInPutFile = Path.Combine (currentFolder, nameInPutFile);

		string[] lines_User = File.ReadAllLines (pathInPutFile);

		Dictionary<string, string> myDicToLoad = new Dictionary<string, string> ();

		foreach (string line in lines_User) {
		
			if (line.Count (f => f=='|') == 1) {
				List<string> listKeyValue = line.Split ('|').ToList ();
				if (!myDicToLoad.Keys.Contains (listKeyValue [0])) {
					myDicToLoad.Add (listKeyValue [0], listKeyValue [1]);
				} else {
				
					myDicToLoad [listKeyValue [0]] = listKeyValue [1];
				}
			}
		}


		foreach (string myKey in myDicToLoad.Keys) {
			if (myKey == "{TenGiaoVien}") {
				TenGiaoVien.text = myDicToLoad [myKey];
			}
			if (myKey == "{Lop}") {
				Lop.text = myDicToLoad [myKey];
			}
			if (myKey == "{Nhom}") {
				Nhom.text = myDicToLoad [myKey];
			}
			if (myKey == "{TenSinhVien}") {
				TenSinhVien.text = myDicToLoad [myKey];
			}
		}



	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Result!: " + www.text);// contains all the data sent from the server

			if(!www.text.Contains("SBVL@2021"))
			{
				print ("quitting");
				Application.Quit ();

			}
            else
            {
				print("pass license");
			}

		} else {
			Debug.Log("WWW Error: "+ www.error);
			print ("quitting");
			Application.Quit ();
		}    
	}
}
