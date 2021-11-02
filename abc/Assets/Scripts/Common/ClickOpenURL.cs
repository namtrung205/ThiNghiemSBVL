using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOpenURL : MonoBehaviour {

    public void OpenURL()
    {
        Application.OpenURL("https://www.utc.edu.vn/");
        Debug.Log("is this working?");
    }
}
