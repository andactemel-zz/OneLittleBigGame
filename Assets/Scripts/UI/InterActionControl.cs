using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InterActionControl : MonoBehaviour {

    SpriteRenderer _ItselfSR;
    Text _InteractionUIText;
    // Use this for initialization
    void Awake()
    {
        _ItselfSR = GetComponent<SpriteRenderer>();
        _InteractionUIText = GameObject.Find("InteractionUIText").GetComponent<Text>();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetState(StateOfUIInterAction SUII,InterActionUI _InterActionUI)
    {
        if (_InterActionUI == null)
        {
           
            transform.position = Vector3.zero;
            _ItselfSR.enabled = false;
            _InteractionUIText.text = "";
            return;
        }
        transform.position = _InterActionUI.gameObject.transform.position;
        if (SUII == StateOfUIInterAction.Opened)
        {
            _ItselfSR.sprite = _InterActionUI.GetInterActionUISprite();
            _InteractionUIText.text = _InterActionUI.info;
            _ItselfSR.enabled = true;

           
          
        }else if(SUII == StateOfUIInterAction.Closed)
        {
            _ItselfSR.enabled = false;
            _InteractionUIText.text = "";

        }
       
    }
    



}

public enum StateOfUIInterAction
{
    Closed=0,Opened=1,Passive=2
}

public enum UIInterActionType
{
    Take = 0, Use = 1, 
}

public class UIInterActionInfo{
    public string info { get; set; }

}

