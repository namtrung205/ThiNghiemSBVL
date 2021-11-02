using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ExportReport : MonoBehaviour {

	public string txtFile = "";
	public string templateFile = "";
	public string tenSinhVien = "";

    public void MakeReport() {

        //will open from the applications dataPath directory
		System.Diagnostics.Process.Start("ModifyPdf.exe",
			txtFile+ " " + templateFile+ " " + tenSinhVien);
    }

}
