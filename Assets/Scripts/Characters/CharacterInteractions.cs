using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractions : MonoBehaviour {
   
    public GameObject interActionOpenUI;
    public Sprite KeyboardSelectUi;
    public Sprite GamePadSelectUi;
	// Use this for initialization
	void Start () {
        
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate(){

        int itemLayerMask = LayerMask.GetMask("itemLayer");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1f, itemLayerMask);
        if (hit.collider != null)
        {

            //TO DO 
            //item menu selector will opened
            interActionOpenUI.GetComponent<SpriteRenderer>().enabled = true;
            interActionOpenUI.transform.position = hit.collider.gameObject.transform.position ;

        }else
        {
            interActionOpenUI.GetComponent<SpriteRenderer>().enabled = false;
        }

        Debug.DrawLine(transform.position,transform.position+transform.up,Color.red,0.1f);
        
    }
    public void ChangeSelectUI(bool joyStick) {
        if (joyStick) {
            interActionOpenUI.GetComponent<SpriteRenderer>().sprite = GamePadSelectUi;
        }else{
            interActionOpenUI.GetComponent<SpriteRenderer>().sprite = KeyboardSelectUi;
        }
    }
 }
