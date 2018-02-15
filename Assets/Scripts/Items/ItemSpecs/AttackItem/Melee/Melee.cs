using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : AttackItem {
    public float _range = 1f;

  
   
	// Use this for initialization
	public override void Start () {
        base.Start();
        _WeaponType = AttackWeaponType.Melee;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
}
