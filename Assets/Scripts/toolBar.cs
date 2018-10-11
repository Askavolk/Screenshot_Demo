using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toolBar : MonoBehaviour {

    private int toolbarInt = 0;
    private string[] toolbarStrings = { "Draw", "Erase", "Save" };


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnGUI() {
        toolbarInt = GUI.Toolbar(new Rect(25, 25, 250, 30), toolbarInt, toolbarStrings);
    }
}
