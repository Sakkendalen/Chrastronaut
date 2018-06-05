using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour {

    bool left;
    int myValues;

	// Use this for initialization
	void Start () {
        left = false;
        myValues = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (left == true) {
            transform.Translate(Vector2.left * 0.01f);
            myValues--;
        }
        else {
            transform.Translate(Vector2.left * -0.01f);
            myValues++;
        }

        if ( myValues > 400)
        {
            left = true;
        }
        if (myValues < 0f)
        {
            left = false;
        }

    }
}
