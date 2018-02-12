﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour,OnTheGroundViewInterFace {
    public float weight = 0f;
    public SpriteRenderer OnTheGroundSpriteRenderer;
    public BoxCollider2D _Walkable_Collider;
    public BoxCollider2D _Interactable_Collider;
    public bool _Walkable_Status=true;
    public InventoryControl _InventoryControl;
    public bool _interactable = true;

    // Use this for initialization
     public virtual void Start () {
        _Walkable_Collider = transform.parent.GetComponent<BoxCollider2D>();
        _Interactable_Collider = transform.GetComponent<BoxCollider2D>();
        OnTheGroundSpriteRenderer = GetComponent<SpriteRenderer>();
        SetWalkableStatus(_Walkable_Status);
        _InventoryControl = GameObject.FindGameObjectWithTag("inventory").GetComponent<InventoryControl>();
        SetInteractable(_interactable);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public virtual void InterAction()
    {
        Debug.Log("Item InterAction Working Now");
    }

    public virtual void SetVisibleOnGround()
    {
        OnTheGroundSpriteRenderer.enabled = true;
    }


    public virtual void SetInVisibleOnGround()
    {
        OnTheGroundSpriteRenderer.enabled = false;
    }

    public virtual void SetOntheGroundSprite(Sprite OntheGround_New)
    {
        OnTheGroundSpriteRenderer.sprite= OntheGround_New;
    }

    public virtual Sprite GetOntheGroundSprite()
    {
        return OnTheGroundSpriteRenderer.sprite;
    }

    public void SetWalkableStatus(bool Walkable)
    {
        _Walkable_Collider.enabled = !Walkable;
    }

    public void SetInteractable(bool interactable)
    {
        _Interactable_Collider.enabled = interactable;
    }
}
