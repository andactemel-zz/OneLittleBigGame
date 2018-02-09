using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour,OnTheGroundViewInterFace {
    public float weight = 0f;
    public SpriteRenderer OnTheGroundSpriteRenderer;
    public BoxCollider2D _Walkable_Collider;
    public bool _Walkable_Status=true;

    // Use this for initialization
     public virtual void Start () {
        _Walkable_Collider = transform.parent.GetComponent<BoxCollider2D>();
        OnTheGroundSpriteRenderer= GetComponent<SpriteRenderer>();
        SetWalkableStatus(_Walkable_Status);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public virtual void InterAction()
    {
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
        _Walkable_Collider.enabled = !_Walkable_Status;
    }
}
