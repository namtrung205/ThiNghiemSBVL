using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundPressButton : MonoBehaviour {

    public AudioSource pressButtonSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playPressButton()
    {
        pressButtonSound.loop = false;
        pressButtonSound.Play();
    }
}
