using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ShowVideoHelp : MonoBehaviour
{

	private string helpPathFile;


//	// Use this for initialization
//	void Start()
//	{
//		string currentFolder = Directory.GetCurrentDirectory();
//
//		helpPathFile = Path.Combine(currentFolder, helpPathFile);
//	}
//
//	// Update is called once per frame
//	void Update()
//	{
//
//	}


	public void ClickToShowVideo(string helpPathFileRela)
	{
		print ("Show help");
		string currentFolder = Directory.GetCurrentDirectory();
		print(currentFolder);
		helpPathFile = Path.Combine(currentFolder, helpPathFileRela);
		print(helpPathFile);
		System.Diagnostics.Process.Start (@helpPathFile);
	}



}
