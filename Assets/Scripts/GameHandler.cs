﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

	// Use this for initialization
	 void Start () {
		
	}
	
	// Update is called once per frame
	 void Update () {

        //Draw Script
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
         || Input.GetMouseButton(0))

        {
            Plane objPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);

            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (objPlane.Raycast(mRay, out rayDistance))
                this.transform.position = mRay.GetPoint(rayDistance);


        }
        
        
        
        
        //This Allow us to actually take screenshot when we press spacebar.

        if (Input.GetKeyDown(KeyCode.Space))
        {
            screenShot.TakeScreenshot_Static(Screen.width, Screen.height);
        }
	}
}
