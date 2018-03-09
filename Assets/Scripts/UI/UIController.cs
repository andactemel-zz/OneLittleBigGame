using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour {
    public bool _OpenedUI = false;
    public bool _OpenedGameUI = false;
    public bool _OpenedSystemUI = false;
    public GameObject _GameUI;
    public GameObject _SystemUI;
    public UISelect _UISelect;

    public ItemCreateInScrollView AttackItem_Content;
    public ItemCreateInScrollView DefenceItem_Content;

    public Image Attack_Item_Equipped;
    public Sprite Default_Attack_Item_Equipped;

    public Image Helmet_Item_Equipped;
    public Sprite Default_Helmet_Item_Equipped;


    void Start () {
        _UISelect = GameObject.FindGameObjectWithTag("UISelect").GetComponent<UISelect>();
	}
	void Update () {
		if(Input.GetButtonUp("Cancel") || Input.GetButtonUp("Cancel_Pad"))
        {
            ToggleSystemUI();
        }
        if (Input.GetButtonUp("Menu") || Input.GetButtonUp("Menu_Pad"))
        {
            ToggleGameUI();
        }
    }
   
    public void ToggleGameUI()
    {
        if (_OpenedSystemUI) { ToggleSystemUI(); }
        _OpenedGameUI = !_OpenedGameUI;
        _GameUI.SetActive(_OpenedGameUI);
        _OpenedUI = _OpenedGameUI || _OpenedSystemUI;
        _UISelect.SetStatus(_OpenedUI);
    }
    public void ToggleSystemUI()
    {
        if (_OpenedGameUI) { ToggleGameUI(); }
        _OpenedSystemUI = !_OpenedSystemUI;
        _SystemUI.SetActive(_OpenedSystemUI);
        _OpenedUI = _OpenedGameUI || _OpenedSystemUI;
        _UISelect.SetStatus(_OpenedUI);
    }

    public void ChangeUIAttackItem(AttackItem attack_item)
    {
        if (attack_item == null)
        {
            Attack_Item_Equipped.sprite = Default_Attack_Item_Equipped;
            return;
        }
        Attack_Item_Equipped.sprite = attack_item._Inventory_Icon;
    }

    public void ChangeUIHelmetItem(Helmet helmet_item)
    {
        if (helmet_item == null)
        {
            Helmet_Item_Equipped.sprite = Default_Helmet_Item_Equipped;
            return;
        }
        Helmet_Item_Equipped.sprite = helmet_item._Inventory_Icon;
    }

    public GameObject[] Panes;
   
    public void SetItselActiceAllInactiveForInventory(GameObject clicked)
    {
        foreach(GameObject pane in Panes)
        {
            if (pane.Equals(clicked))
            {
                pane.SetActive(true);
            }else
            {
                pane.SetActive(false);
            }
        }
    }

}
