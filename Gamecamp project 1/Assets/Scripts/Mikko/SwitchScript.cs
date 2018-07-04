using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour {

    public GameObject PillarsPuzzle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        

        if ( gameObject.name == "Switch1") {
            PillarsPuzzle.GetComponent<PillarsPuzzle>().Switch1Pressed();
        }
        if (gameObject.name == "Switch2") {
            PillarsPuzzle.GetComponent<PillarsPuzzle>().Switch2Pressed();
        }
    }
}
