using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemCreateInScrollView : MonoBehaviour {
    public GameObject SlotItem;
	// Use this for initialization
	void Start () {
       // CreateItemSlots(null);
    }
	
	// Update is called once per frame
	void Update () {
        

    }

    public void ClearSlots()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy( transform.GetChild(i).gameObject);
        }
    }
    public void CreateItemSlots(List<Item> Items)
    {
        ClearSlots();
        Debug.Log("attack ıtemları guncellendi ui da");
        RectTransform ContentRect = GetComponent<RectTransform>();

        int itemCount = Items.Count;
        
        int ColumnCount = 4;
        float width_Item = ContentRect.rect.width / (float)ColumnCount;
        float height_Item = width_Item;
        float row_Count = ((itemCount / ColumnCount) + 1);
        float Content_Height = (row_Count) * height_Item;
        ContentRect.sizeDelta = new Vector2(ContentRect.rect.width, Content_Height);
        for(int i = 0; i < itemCount; i++)
        {
            GameObject item = GameObject.Instantiate(SlotItem) as GameObject;
            item.transform.SetParent(transform);
            RectTransform item_Rect_Transform = item.GetComponent<RectTransform>();
            item_Rect_Transform.sizeDelta = new Vector2(width_Item, height_Item);
            item_Rect_Transform.anchoredPosition = new Vector2((i%ColumnCount)*width_Item,((i/ColumnCount)*height_Item)*-1);
            item.GetComponent<ItemHolder>()._Item = Items[i];
            if (Items[i]._Inventory_Icon != null) { item.transform.GetChild(0).GetComponent<Image>().sprite = Items[i]._Inventory_Icon; }

        }

    }
    
}
