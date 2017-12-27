using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiControlChanger : MonoBehaviour {


    public CharacterInteractions _CharacterInteractions;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateUIAccordingToControlChange(bool joystick)
    {
        _CharacterInteractions.ChangeSelectUI(joystick);
    }
}
