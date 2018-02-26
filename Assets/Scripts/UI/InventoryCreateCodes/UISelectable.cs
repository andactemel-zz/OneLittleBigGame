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
        _UISelect.ComeToMe(GetComponent<RectTransform>());
    }


    void Start () {
        _UISelect = GameObject.FindGameObjectWithTag("UISelect").GetComponent<UISelect>();
	}
}
