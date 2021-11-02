using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class QuitScript : MonoBehaviour {

	public string nameOutPutFile = @"Templates\OutPut_User.txt";
	// Update is called once per frame
	public void QuitMyApp(){

		//Clear Data
		string currentFolder = Directory.GetCurrentDirectory ();

		string pathOutPutFile = Path.Combine (currentFolder, nameOutPutFile);

		//Clear text
		File.WriteAllText(pathOutPutFile, string.Empty);

		print ("Quit");
		Application.Quit ();
		print ("Quit2");
	}
		
	}

