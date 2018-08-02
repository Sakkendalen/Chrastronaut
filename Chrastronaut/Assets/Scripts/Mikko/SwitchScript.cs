using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour {

    public GameObject PillarsPuzzle;

	float starty;
	bool animationdown;

	// Use this for initialization
	void Start () {
		animationdown = false;
		starty = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

		if (animationdown == true && transform.position.y > starty - 0.5f) {
			transform.Translate (Vector3.down * 0.01f);
		} 
		else {
			if (animationdown == true) {
				animationdown = false;
				if ( gameObject.name == "Switch1") {
					PillarsPuzzle.GetComponent<PillarsPuzzle>().Switch1Pressed();
				}
				if (gameObject.name == "Switch2") {
					PillarsPuzzle.GetComponent<PillarsPuzzle>().Switch2Pressed();
				}
			}

		}



		if (animationdown == false && transform.position.y < starty) {
			transform.Translate (Vector3.down * -0.01f);
		}
		
	}

    private void OnCollisionEnter2D(Collision2D collision) {

		if (animationdown == false && transform.position.y >= starty -0.1f) {
			animationdown = true;
		}
			

        //if ( gameObject.name == "Switch1") {
        //    PillarsPuzzle.GetComponent<PillarsPuzzle>().Switch1Pressed();
        //}
        //if (gameObject.name == "Switch2") {
        //    PillarsPuzzle.GetComponent<PillarsPuzzle>().Switch2Pressed();
        //}


    }
}
