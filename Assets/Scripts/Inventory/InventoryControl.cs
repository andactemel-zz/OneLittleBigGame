using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour {
    public Transform AttackItem;
    public Transform DefenceItem;
    public Transform JeweleryItem;
    public Transform PotionItem;
    public Transform WareItem;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GetItemToBag(Item item)
    {
        item.SetInVisibleOnGround();
        item.SetWalkableStatus(true);
        item.SetInteractable(false);
        item.transform.parent.SetParent( DetermineInventorySlot(item));
        item.transform.parent.localPosition = Vector3.zero;
    }

    Transform DetermineInventorySlot(Item item)
    {
       
        if(item is AttackItem)
        {
           
            return AttackItem;
        }
        return WareItem;
    }



}
