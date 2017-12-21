using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControl : MonoBehaviour {
	public ControlMeta _ControlMeta;
	// Use this for initialization
	void Start () {
		//Debug.Log ("dsd");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RotationControlScript(){
	
		if (_ControlMeta._ControlMethod.joystick) {
			if (((Input.GetAxis ("Mouse X_Pad") < 1.1f && Input.GetAxis ("Mouse X_Pad") > -1.1f) && (Input.GetAxis ("Mouse X_Pad") > 0.2f || Input.GetAxis ("Mouse X_Pad") < -0.2f))
			    || ((Input.GetAxis ("Mouse Y_Pad") < 1.1f && Input.GetAxis ("Mouse Y_Pad") > -1.1f) && (Input.GetAxis ("Mouse Y_Pad") > 0.1f || Input.GetAxis ("Mouse Y_Pad") < -0.1f))) {

				Vector3 LookDirection = new Vector3 (transform.position.x + Input.GetAxis ("Mouse X_Pad"), transform.position.y - Input.GetAxis ("Mouse Y_Pad"), -10f);
				Debug.Log (LookDirection);
				Quaternion rotati = Quaternion.LookRotation (transform.position - LookDirection, Vector3.forward);
				transform.rotation = rotati;
				transform.eulerAngles = new Vector3 (0, 0, transform.localEulerAngles.z);
				_ControlMeta._MoveControl._CharacterRigidbody2D.angularVelocity = 0;
			
			}
			
		} else {
			
			var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Debug.Log (mousePosition);
			Quaternion rotati = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);
			transform.rotation = rotati;
			transform.eulerAngles = new Vector3 (0, 0, transform.localEulerAngles.z);
			_ControlMeta._MoveControl._CharacterRigidbody2D.angularVelocity = 0;

		}
	}
}
