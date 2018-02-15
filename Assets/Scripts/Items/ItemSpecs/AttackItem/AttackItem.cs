using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackItem : Item {

    public float Damage = 1f;
    public float Speed = 1f;
   
    public AttackWeaponType _WeaponType;
    public Sprite _WeaponOnTheCharacterSprite;
    // Use this for initialization
    public override void Start () {
        base.Start();
      
	}
	
	// Update is called once per frame
	void Update () {
		
	}
  
}
