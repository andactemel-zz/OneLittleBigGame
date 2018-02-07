using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InterActionUI : MonoBehaviour
{
    public Sprite KeyboardInterActionUI;
    public Sprite GamePadInterAction;

    public string info;


    ControlMeta _ControlMeta;

    void Awake()
    {
        gameObject.layer = LayerMask.NameToLayer("interactionUILayer");
        _ControlMeta = Camera.main.GetComponent<ControlMeta>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public Sprite GetInterActionUISprite()
    {
        if (_ControlMeta._ControlMethod.joystick)
        {
            return GamePadInterAction;
        }
        return KeyboardInterActionUI;
    }

    public void CallInterActionOption()
    {
        GetComponent<Item>().InterAction();
    }
}
 
