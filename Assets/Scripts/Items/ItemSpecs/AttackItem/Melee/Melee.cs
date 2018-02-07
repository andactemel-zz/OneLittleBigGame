using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : AttackItem {
    public float _range = 1f;

    public Sprite _Sprite;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void InterAction()
    {
        Debug.Log("Melee");
    }
}
