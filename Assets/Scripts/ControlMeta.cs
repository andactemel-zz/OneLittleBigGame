using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMeta : MonoBehaviour {
	public ControlMethod _ControlMethod;
	public MoveControl _MoveControl;
	public RotationControl _RotationControl;
	public CameraControl _CameraControl;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Choosing whic controller used according to user input
		_ControlMethod.ControlMethodScript ();


	}
	void FixedUpdate(){
	
		//Move the Character According to left stick input or wasd
		_MoveControl._MoveControlScript ();
		//Rotate The Character According to Mouse Position or Right Analog
		_RotationControl.RotationControlScript();
		//Camera Follow Character
		_CameraControl.CameraControlScript();

	}
}
