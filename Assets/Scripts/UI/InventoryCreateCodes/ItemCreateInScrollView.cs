using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemCreateInScrollView : MonoBehaviour {
    public GameObject SlotItem;
    public UISelect _UISelect;
    public int columnCount;
    public Selectable _Left;
    public Selectable _Right;
	public Selectable _Up;
	public Selectable _Down;

    // Use this for initialization
    void Start () {
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
        RectTransform ContentRect = GetComponent<RectTransform>();
        int itemCount = Items.Count;
        float width_Item = ContentRect.rect.width / (float)columnCount;
        float height_Item = width_Item;
        float row_Count = ((itemCount / columnCount) + 1);
        float Content_Height = (row_Count) * height_Item;
        ContentRect.sizeDelta = new Vector2(ContentRect.rect.width, Content_Height);
        for(int i = 0; i < itemCount; i++)
        {
            GameObject item = GameObject.Instantiate(SlotItem) as GameObject;
            item.transform.SetParent(transform);
            RectTransform item_Rect_Transform = item.GetComponent<RectTransform>();
            item_Rect_Transform.sizeDelta = new Vector2(width_Item, height_Item);
            item_Rect_Transform.anchoredPosition = new Vector2((i% columnCount) *width_Item,((i/ columnCount) *height_Item)*-1);
            item.GetComponent<UISelectable>()._Item = Items[i];
            if (Items[i]._Inventory_Icon != null) { item.transform.GetChild(0).GetComponent<Image>().sprite = Items[i]._Inventory_Icon; }

        }
        
      
    }
    void OnEnable()
    {
       MakeNavigationBinding();
    }
   public void MakeNavigationBinding()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
			Navigation customNav = new Navigation();
			customNav.mode = Navigation.Mode.Explicit;
			//Make Up Binding
			if ((i - columnCount) < 0) {
				customNav.selectOnUp = _Up;
			} else {
				customNav.selectOnUp = transform.GetChild (i - columnCount).GetComponent<Button> ();
			}
			//Make Right Binding
			if ((i + 1) >= transform.childCount || i%columnCount==3) {
				customNav.selectOnRight = _Right;
			} else {
				
				customNav.selectOnRight = transform.GetChild (i + 1).GetComponent<Button> ();
			}
			//Make Down Binding
			if ((i + columnCount) < transform.childCount) {
				customNav.selectOnDown = transform.GetChild (i + columnCount).GetComponent<Button> ();
			} else {
				customNav.selectOnDown = _Down;
			}

			//Make Left Binding

			if (i-1 < 0 || (i)%columnCount==0) {
				customNav.selectOnLeft = _Left;
			} else {
				customNav.selectOnLeft = transform.GetChild (i - 1).GetComponent<Button> ();
			}
			transform.GetChild(i).GetComponent<Button>().navigation = customNav;
        }
    }


    
}
