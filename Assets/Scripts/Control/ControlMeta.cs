using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMeta : MonoBehaviour {
	public ControlMethod _ControlMethod;
	public MoveControl _MoveControl;
	public RotationControl _RotationControl;
	public CameraControl _CameraControl;
    public CharacterAttack _CharacterAttack;
    public UIController _UIController;


    public bool rotationControlActive = true;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Choosing whic controller used according to user input
		_ControlMethod.ControlMethodScript ();


	}
	void FixedUpdate(){
        if (_UIController._OpenedUI) { return; }//If  UI Opened Cancel Movement
		//Move the Character According to left stick input or wasd
		_MoveControl._MoveControlScript ();
        //Rotate The Character According to Mouse Position or Right Analog
        if (rotationControlActive)
        {
            _RotationControl.RotationControlScript();
        }
		//Camera Follow Character
		_CameraControl.CameraControlScript();
        _CharacterAttack.ChracterAtttackScript();


    }
}
