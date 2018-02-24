using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    public bool _OpenedUI = false;
    public bool _OpenedGameUI = false;
    public bool _OpenedSystemUI = false;
    // Use this for initialization

    public GameObject _GameUI;
    public GameObject _SystemUI;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonUp("Cancel") || Input.GetButtonUp("Cancel_Pad"))
        {
            ToggleSystemUI();
        }
        if (Input.GetButtonUp("Menu") || Input.GetButtonUp("Menu_Pad"))
        {
            ToggleGameUI();
        }
    }

    public void ToggleGameUI()
    {
        if (_OpenedSystemUI) { ToggleSystemUI(); }
        _OpenedGameUI = !_OpenedGameUI;
        _GameUI.SetActive(_OpenedGameUI);
        _OpenedUI = _OpenedGameUI || _OpenedSystemUI;

    }
    public void ToggleSystemUI()
    {
        if (_OpenedGameUI) { ToggleGameUI(); }
        _OpenedSystemUI = !_OpenedSystemUI;
        _SystemUI.SetActive(_OpenedSystemUI);
        _OpenedUI = _OpenedGameUI || _OpenedSystemUI;
    }



}
