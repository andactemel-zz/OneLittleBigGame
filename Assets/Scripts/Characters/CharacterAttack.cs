using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour {
    public ControlMeta _ControlMeta;
    public CharacterAnimationControl _CharacterAnimationControl;

    InventoryControl IC;
    // Use this for initialization
    void Start () {
        IC = GameObject.FindGameObjectWithTag("inventory").GetComponent<InventoryControl>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public float GetCharacterAttackSpeed()
    {
        return 1f;
    }
    public void ChracterAtttackScript()
    {
       // Debug.Log(Input.GetAxis("Fire1"));
        if (_ControlMeta._ControlMethod.joystick)
        {
            //When Joystick X input Came takes it move the character
            if (Input.GetAxis("Fire1_Pad") > 0f)
            {

                // _CharacterAnimationControl.AttackMeleeStart(GetCharacterAttackSpeed());
                _CharacterAnimationControl.AnimationAttackStart(GetCharacterAttackSpeed(), IC.GetEquippedAttackItem());
            }
            else
            {
                // _CharacterAnimationControl.AttackMeleeFinish();
                _CharacterAnimationControl.AnimationAttackFinish(GetCharacterAttackSpeed(), IC.GetEquippedAttackItem());
            }


        }
        else
        {

            //When LeftMouseButton input Came, takes it move the character
            if (Input.GetAxis("Fire1") > 0f)
            {

                //_CharacterAnimationControl.AttackMeleeStart(GetCharacterAttackSpeed());
                _CharacterAnimationControl.AnimationAttackStart(GetCharacterAttackSpeed(), IC.GetEquippedAttackItem());
            }
            else
            {
                //_CharacterAnimationControl.AttackMeleeFinish();
                _CharacterAnimationControl.AnimationAttackFinish(GetCharacterAttackSpeed(), IC.GetEquippedAttackItem());
            }
        }

    }
}
