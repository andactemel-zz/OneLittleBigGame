using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour {
    public Transform AttackItem;
    public Transform DefenceItem;
    public Transform JeweleryItem;
    public Transform PotionItem;
    public Transform WareItem;

    public UIController _UIController;
    public UISelect _UISelect;

    Character _Character;

    AttackItem _EquippedAttackItem;
    Helmet _EquippedHelmet;



    // Use this for initialization
    void Start () {
        _Character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        _UIController = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();
        _UISelect = GameObject.FindGameObjectWithTag("UISelect").GetComponent<UISelect>();
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

        //EquipAttackItem((AttackItem)item);
        //EquipDefenceItem((DefenceItem)item);
       
    }
    public void EquipDefenceItem(DefenceItem item)
    {
        if(item is Helmet)
        {
            EquipHelmet((Helmet)item);
        }
    }
    void EquipHelmet(Helmet helmet)
    {
        UnEquipHelmet();
        _Character.HelmetItemCharacterSlot.SetActive(true);
        _Character.HelmetItemCharacterSlot.GetComponent<SpriteRenderer>().sprite = helmet.HelmetOntheCharacterSprite;
        _EquippedHelmet = helmet;
        _EquippedHelmet._equipped = true;
        _UIController.ChangeUIHelmetItem(helmet);
    }
   
    public void UnEquipHelmet()
    {
        Debug.Log("UnEquip Helmet");
        if (_EquippedHelmet != null) { _EquippedHelmet._equipped = false; }
        _EquippedHelmet = null;
        _Character.HelmetItemCharacterSlot.SetActive(false);
        _UIController.ChangeUIHelmetItem(null);
        StartCoroutine(CallUpdateBag(DefenceItem));
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
        _UIController.ChangeUIAttackItem(item);
    }

   
    void EquipAttackItemGeneral(GameObject _SlotOnCharacterSprite,AttackItem _attackItem)
    {
        _SlotOnCharacterSprite.SetActive(true);
        _SlotOnCharacterSprite.GetComponent<SpriteRenderer>().sprite = _attackItem._WeaponOnTheCharacterSprite;
        _EquippedAttackItem = _attackItem;
        _EquippedAttackItem._equipped = true;
    }

     public  void UnEquipWeapons()
    {
        if (_EquippedAttackItem != null) { _EquippedAttackItem._equipped = false; }
        _EquippedAttackItem = null;
        _Character.MeleeItemCharacterSlot.SetActive(false);
        _Character.CrossBowItemCharacterSlot.SetActive(false);
        _UIController.ChangeUIAttackItem(null);
        StartCoroutine(CallUpdateBag(AttackItem));
    }
    public List<Item> GetItemsInTheBag(Transform Parent)
    {
        List<Item> Items = new List<Item>();
        foreach(Transform child in Parent)
        {
            if (!child.GetChild(0).GetComponent<Item>()._equipped)
            {
                Items.Add(child.GetChild(0).GetComponent<Item>());
            }
        }
        return Items;
    }
    public IEnumerator CallUpdateBag(Transform Parent)
    {
        //Waiting for update gme itself
        yield return null;
        _UISelect.MakeTopOfEveryThing();
        _UISelect.ComeToMe(_UISelect._EventSystem.firstSelectedGameObject.GetComponent<RectTransform>());
        yield return null;
        //Takes all the items in the desired inventory slots and pass them to ui controller attack ıtem window create when any changes in the inventory
        if (Parent == AttackItem) { _UIController.AttackItem_Content.CreateItemSlots(GetItemsInTheBag(Parent)); }
        if (Parent == DefenceItem) { _UIController.DefenceItem_Content.CreateItemSlots(GetItemsInTheBag(Parent)); }

    }
    Transform DetermineInventorySlot(Item item)
    {
        //Determine inventoryslots and update bag accordingly;
       
        if(item is AttackItem)
        {
            StartCoroutine(CallUpdateBag(AttackItem));
            return AttackItem;
        }else if(item is DefenceItem) 
        {
            StartCoroutine(CallUpdateBag(DefenceItem));
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
