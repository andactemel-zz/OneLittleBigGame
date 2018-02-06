using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterActionControl : MonoBehaviour {

    public Sprite KeyboardSelectUi;
    public Sprite GamePadSelectUi;
  
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetState(StateOfUIInterAction SUII,Vector3 Position)
    {
        if (SUII == StateOfUIInterAction.Opened)
        {
            GetComponent<SpriteRenderer>().enabled = true;
          
        }else if(SUII == StateOfUIInterAction.Closed)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            
        }
        transform.position = Position;
    }
    


    public void ChangeSelectUI(bool joyStick)
    {
        if (joyStick)
        {
            GetComponent<SpriteRenderer>().sprite = GamePadSelectUi;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = KeyboardSelectUi;
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

