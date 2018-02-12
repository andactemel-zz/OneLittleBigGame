using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InterActionControl : MonoBehaviour {

    ControlMeta _ControlMeta;
    SpriteRenderer _ItselfSR;
    Text _InteractionUIText;

    public bool ListenEvent = false;
    InterActionUI _Active;
    // Use this for initialization
    void Awake()
    {
        _ItselfSR = GetComponent<SpriteRenderer>();
        _InteractionUIText = GameObject.Find("InteractionUIText").GetComponent<Text>();
        _Active = null;
        _ControlMeta = Camera.main.GetComponent<ControlMeta>();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (ListenEvent)
        {
            if (_ControlMeta._ControlMethod.joystick)
            {
                if (Input.GetButtonUp("Fire2_Pad"))
                {
                    _Active.CallInterActionOption();
                }
            }
            else
            {
                if (Input.GetButtonUp("Fire2"))
                {
                    _Active.CallInterActionOption();
                }
            }
        }
	}

    public void SetState(StateOfUIInterAction SUII,InterActionUI _InterActionUI)
    {
        if (_InterActionUI == null)
        {
           
            transform.position = Vector3.zero;
            _ItselfSR.enabled = false;
            _InteractionUIText.text = "";
            ListenEvent = false;
            return;
        }
        transform.position = _InterActionUI.gameObject.transform.position;
        if (SUII == StateOfUIInterAction.Opened)
        {
            _ItselfSR.sprite = _InterActionUI.GetInterActionUISprite();
            _InteractionUIText.text = _InterActionUI.info;
            _ItselfSR.enabled = true;
            ListenEvent = true;
            _Active = _InterActionUI;




        }
        else if(SUII == StateOfUIInterAction.Closed)
        {
            _ItselfSR.enabled = false;
            _InteractionUIText.text = "";
            _InterActionUI = null;
            ListenEvent = false;
            _Active = null;
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

