using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour {
    public ControlMeta _ControlMeta;
    public CharacterAnimationControl _CharacterAnimationControl;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChracterAtttackScript()
    {
        Debug.Log(Input.GetAxis("Fire1"));
        if (_ControlMeta._ControlMethod.joystick)
        {
            //When Joystick X input Came takes it move the character
           
        

        }
        else
        {

            //When LeftMouseButton input Came, takes it move the character
            if (Input.GetAxis("Fire1") > 0f)
            {

                _CharacterAnimationControl.AttackMeleeStart();
            }
            else
            {
                _CharacterAnimationControl.AttackMeleeFinish();
            }
        }

    }
}
