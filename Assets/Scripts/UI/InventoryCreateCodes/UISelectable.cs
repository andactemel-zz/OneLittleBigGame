using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISelectable : MonoBehaviour, IPointerEnterHandler
{
    public UISelect _UISelect;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("On ME");
        _UISelect.ComeToMe(GetComponent<RectTransform>());
    }

    // Use this for initialization
    void Start () {
        _UISelect = GameObject.FindGameObjectWithTag("UISelect").GetComponent<UISelect>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
