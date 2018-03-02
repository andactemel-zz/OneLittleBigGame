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
    // Use this for initialization
    void Start () {
        // CreateItemSlots(null);
        columnCount = 4;
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
        
        int columnCount = 4;
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
    void MakeUINavigationAutomatic(Button UI) {
        Navigation customNav = new Navigation();
        customNav.mode = Navigation.Mode.Automatic;
        UI.navigation = customNav;
    }
    void MakeUINavigationExplicitCenter(int child_number)
    {
        Navigation customNav = new Navigation();
        customNav.mode = Navigation.Mode.Explicit;
        customNav.selectOnDown = transform.GetChild(child_number + columnCount).GetComponent<Selectable>();
        customNav.selectOnUp = transform.GetChild(child_number - columnCount).GetComponent<Selectable>();
        customNav.selectOnRight = transform.GetChild(child_number + 1).GetComponent<Selectable>();
        customNav.selectOnLeft = transform.GetChild(child_number - 1).GetComponent<Selectable>();
        transform.GetChild(child_number).GetComponent<Button>().navigation = customNav;
    }
    void MakeUINavigationExplicitLeft(int child_number)
    {
        Navigation customNav = new Navigation();
        customNav.mode = Navigation.Mode.Explicit;
        customNav.selectOnDown = transform.GetChild(child_number + columnCount).GetComponent<Selectable>();
        customNav.selectOnUp = transform.GetChild(child_number - columnCount).GetComponent<Selectable>();
        customNav.selectOnRight = transform.GetChild(child_number + 1).GetComponent<Selectable>();
        customNav.selectOnLeft = _Left;
        transform.GetChild(child_number).GetComponent<Button>().navigation = customNav;
    }
    void MakeUINavigationExplicitRight(int child_number)
    { 
		int childCount = FindFirstLevelChildNumberWithTag ("ItemInventoryPanel",transform);
        Navigation customNav = new Navigation();
        customNav.mode = Navigation.Mode.Explicit;
		if((child_number + columnCount) <= childCount-1)
            customNav.selectOnDown = transform.GetChild(child_number + columnCount).GetComponent<Selectable>();
        customNav.selectOnUp = transform.GetChild(child_number - columnCount).GetComponent<Selectable>();
        customNav.selectOnRight = _Right;
        customNav.selectOnLeft = transform.GetChild(child_number - 1).GetComponent<Selectable>();
        transform.GetChild(child_number).GetComponent<Button>().navigation = customNav;
    }
	int FindFirstLevelChildNumberWithTag(string tag,Transform parent){


		int childCount = 0;

		foreach (Transform child in parent) {
			if (child.gameObject.CompareTag(tag)) {
				childCount++;
			}
		}
		return childCount;
	}


    void MakeNavigationBinding()
    {
		int childCount = FindFirstLevelChildNumberWithTag ("ItemInventoryPanel",transform);

		int i = 0;
		foreach (Transform child in transform) {
		
			int lastRowStart = (childCount / 4) * columnCount;
			int lastRowFinish = lastRowStart + (columnCount-1);
			if (i < columnCount)//Make First Column navigationautomatic
			{
				MakeUINavigationAutomatic(transform.GetChild(i).GetComponent<Button>());
			}
			else if(i<=lastRowFinish && i>=lastRowStart)  //Make Last Column navigationautomatic
			{
				MakeUINavigationAutomatic(transform.GetChild(i).GetComponent<Button>());
			}else if(i%columnCount==0)//Make Left Side Automatic
			{
				MakeUINavigationExplicitLeft(i);
			}else if (i % columnCount == 3)//Make Right Side Automatic
			{
				MakeUINavigationExplicitRight(i);
			}else
			{
				if ((i + columnCount) > childCount - 1)
				{
					MakeUINavigationAutomatic(transform.GetChild(i).GetComponent<Button>());
				}else
				{
					MakeUINavigationExplicitCenter(i);
				}
			}
			i++;
		
		}
       /* for(int i = 0; i < transform.childCount; i++)
        {
           

        }*/
    }
    
}
