using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractions : MonoBehaviour {
    int itemLayerMask=-1;//only items can effected by layer
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
        }

        Debug.DrawLine(transform.position,transform.position+transform.up,Color.red,0.1f);
        
    }
 }
