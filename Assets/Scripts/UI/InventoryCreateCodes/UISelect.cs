using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelect : MonoBehaviour {

    public RectTransform _ActiveItem;
    public UIController _UIController;


    RectTransform selfTransform;
    Vector2 targetSize;
    Vector2 targetAnchor;
    float sizeTreshold;
    float anchorTreshold;
    float sizeAnimationSpeed;
    float moveAnimationSpeed;
    public bool go = false;
	// Use this for initialization 
	void Start () {
        _UIController = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();
        targetSize = GetComponent<RectTransform>().sizeDelta;
        targetAnchor= GetComponent<RectTransform>().anchoredPosition;
        selfTransform = GetComponent<RectTransform>();
        sizeTreshold = 0.2f;
        anchorTreshold = 0.2f;
        sizeAnimationSpeed = 0.3f;
        moveAnimationSpeed = 0.3f;
    }
	
	// Update is called once per frame
	void Update () {
        if (!go)
        {
            return;
        }
       if(Mathf.Abs(targetSize.x-selfTransform.sizeDelta.x)> sizeTreshold ||
          Mathf.Abs(targetSize.y - selfTransform.sizeDelta.y) > sizeTreshold ||
          Mathf.Abs(targetAnchor.x - selfTransform.anchoredPosition.x) > anchorTreshold ||
          Mathf.Abs(targetAnchor.y - selfTransform.anchoredPosition.y) > anchorTreshold
         )
        {
            Vector2 next_step_size = Vector2.Lerp(selfTransform.sizeDelta, targetSize, sizeAnimationSpeed);
            Vector2 next_step_anchor = Vector2.Lerp(selfTransform.anchoredPosition, targetAnchor, moveAnimationSpeed);
            
            selfTransform.sizeDelta = next_step_size;
            selfTransform.anchoredPosition = next_step_anchor;
            transform.SetParent(_ActiveItem.transform);



        }else
        {
            transform.SetParent(_UIController.transform);
            go = false;
            Debug.Log("Stop");
            
        }
    }
    public void SetStatus(bool status)
    {
        gameObject.SetActive(status);
    }
    public void ComeToMe(RectTransform item)
    {
        
        RectTransform targetTransform = item.gameObject.GetComponent<RectTransform>();
        _ActiveItem = item;
        targetSize= new Vector2(targetTransform.rect.width, targetTransform.rect.height);
        targetAnchor = Vector2.zero;
        go = true;
        transform.SetParent(_ActiveItem.transform);
        //selfTransform.sizeDelta = new Vector2(targetTransform.rect.width, targetTransform.rect.height);
        //selfTransform.anchoredPosition = Vector2.zero;
        //transform.SetParent(_UIController.transform);
    }
}
