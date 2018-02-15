using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBow : Ranged {
   
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        _WeaponType = AttackWeaponType.CrossBow;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
