using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour {
	public ControlMeta _ControlMeta; //MAster Control Script Referance
	public Transform _CharacterTransform;//Character Transform referance
	public Rigidbody2D _CharacterRigidbody2D;//Character Transform referance
	public float speed = 6.0F;
	public Vector2 moveDirection = Vector2.zero;
	public bool PyhsicControl=false;


	// Use this for initialization
	void Start () {
		_CharacterRigidbody2D = _CharacterTransform.GetComponent<Rigidbody2D> ();
	}



	// Update is called once per frame
	void Update () {


		
	}

	public void _MoveControlScript(){
		float input_Vertical=0f;
		float input_Horizontal=0f;
		if (_ControlMeta._ControlMethod.joystick) {
			//When Joystick Left Analog input Came takes it move the character
			input_Vertical=Input.GetAxis("Vertical_Pad");
			input_Horizontal=Input.GetAxis("Horizontal_Pad");

		} else {

			//When Keyboard "wasd" input Came, takes it move the character
			input_Vertical=Input.GetAxis("Vertical");
			input_Horizontal=Input.GetAxis("Horizontal");

		}

		moveDirection = (Vector2.up * input_Vertical + Vector2.right * input_Horizontal).normalized;
		if (PyhsicControl) {
			_CharacterRigidbody2D.AddForce (moveDirection * speed * 10f);
		} else {
			_CharacterTransform.Translate(moveDirection*speed*Time.deltaTime,Space.World);

		}
		//

	}
}
