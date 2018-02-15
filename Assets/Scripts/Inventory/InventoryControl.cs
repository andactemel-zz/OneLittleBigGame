using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour {
    public Transform AttackItem;
    public Transform DefenceItem;
    public Transform JeweleryItem;
    public Transform PotionItem;
    public Transform WareItem;


    Character _Character;

    AttackItem _EquippedAttackItem;
    
    // Use this for initialization
    void Start () {
        _Character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public AttackItem GetEquippedAttackItem()
    {
        return _EquippedAttackItem;
    }

    public void GetItemToBag(Item item)
    {
        item.SetInVisibleOnGround();
        item.SetWalkableStatus(true);
        item.SetInteractable(false);
        item.transform.parent.SetParent( DetermineInventorySlot(item));
        item.transform.parent.localPosition = Vector3.zero;

        EquipAttackItem((AttackItem)item);
    }

    public void EquipAttackItem(AttackItem item)
    {
        UnEquipWeapons();

        if (item == null)
        {
            //Bare Hand Equipped
            return;
        }
        if (item._WeaponType == AttackWeaponType.Melee)
        {
            
            EquipAttackItemGeneral(_Character.MeleeItemCharacterSlot, item);

        }
        else if(item._WeaponType == AttackWeaponType.CrossBow)
        {
          
            EquipAttackItemGeneral(_Character.CrossBowItemCharacterSlot, item);
        }
       
    }

    void EquipAttackItemGeneral(GameObject _SlotOnCharacterSprite,AttackItem _attackItem)
    {
        _SlotOnCharacterSprite.SetActive(true);
        _SlotOnCharacterSprite.GetComponent<SpriteRenderer>().sprite = _attackItem._WeaponOnTheCharacterSprite;
        _EquippedAttackItem = _attackItem;
    }

     public  void UnEquipWeapons()
    {
        _EquippedAttackItem = null;
        _Character.MeleeItemCharacterSlot.SetActive(false);
        _Character.CrossBowItemCharacterSlot.SetActive(false);
    }
    Transform DetermineInventorySlot(Item item)
    {
       
        if(item is AttackItem)
        {
            return AttackItem;
        }else if(item is DefenceItem) 
        {
            return DefenceItem;
        }
        else if (item is JeweleryItem)
        {
            return JeweleryItem;
        }
        else if (item is PotionItem)
        {
            return PotionItem;
        }
        else if (item is WareItem)
        {
            return WareItem;
        }
        return WareItem;
    }



}
