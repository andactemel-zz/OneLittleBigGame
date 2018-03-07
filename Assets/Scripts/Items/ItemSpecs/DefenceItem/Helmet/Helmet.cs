using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helmet : DefenceItem {
    public Sprite HelmetOntheCharacterSprite;
    // Use this for initialization
    public override void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    void Update () {
		
	}
    public override void UIPrimaryAction()
    {
        Debug.Log("Item UI Primary Action Helmet Item");
        _InventoryControl.EquipDefenceItem((DefenceItem)this);
        StartCoroutine(_InventoryControl.CallUpdateBag(_InventoryControl.DefenceItem));
    }
}
