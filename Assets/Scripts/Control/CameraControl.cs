using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
	public ControlMeta _ControlMeta;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void CameraControlScript(){
		//Basic Camera Follow Function
		Camera.main.transform.position=new Vector3( 
			_ControlMeta._MoveControl._CharacterTransform.transform.position.x
			,_ControlMeta._MoveControl._CharacterTransform.transform.position.y
			,-10f
		);
	}
}
