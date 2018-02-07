using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractions : MonoBehaviour {
   
    InterActionControl interActionOpenUI;
  
    
	// Use this for initialization
	void Start () {
       interActionOpenUI = GameObject.FindGameObjectWithTag("InteractionUI").GetComponent<InterActionControl>();
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate(){

        int itemLayerMask = LayerMask.GetMask("interactionUILayer");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1.5f, itemLayerMask);
        if (hit.collider != null)
        {
            interActionOpenUI.SetState(StateOfUIInterAction.Opened, hit.collider.gameObject.GetComponent<InterActionUI>() );
        }
        else
        {
            interActionOpenUI.SetState(StateOfUIInterAction.Closed, null);
        }

        Debug.DrawLine(transform.position,(transform.position+transform.up*1.5f),Color.red,0.1f);
        
    }
    
 }
