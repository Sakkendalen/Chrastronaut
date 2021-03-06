﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubblescript : MonoBehaviour {

    Vector3 startpos;
    bool isFistConnected;
    GameObject fist;
    public GameObject poks;
	int imTooHigh;

	// Use this for initialization
	void Start () {
        startpos = transform.position;
        isFistConnected = false;
        fist = GameObject.Find("Fist");
		imTooHigh = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
        if ( transform.position.y > 10f) {
			imTooHigh++;
            //transform.position = new Vector3(startpos.x, -6f , startpos.z);
            //GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			if (isFistConnected == true && imTooHigh > 0) {
                //release FIST
                fist.GetComponent<Fist2>().SetFistState(3);
				GetComponent<CircleCollider2D>().enabled = false;
            }

			if (imTooHigh >= 5) {
				Instantiate (poks, transform.position, transform.rotation);
				Debug.Log ("Kupla tuhoutui ja koukku oli kiinni : " + isFistConnected);
				Destroy (gameObject);
			}
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Kuplatörmäys");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Kuplatörmäys2");
        if (collision.tag == "Fist") {
            GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        }

        if (collision.name == "Fist") {
            Debug.Log("HIT BY FIST & SET TO TRUE");
            isFistConnected = true;
            GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        }


    }

    private void OnTriggerExit2D(Collider2D collision) {
        Debug.Log("Kuplatörmäys3");
        if (collision.tag == "Fist") {
            GetComponent<Rigidbody2D>().gravityScale = -0.1f;
        }
        if (collision.name == "Fist") {
            //Debug.Log("FIST RELEASE");
            isFistConnected = false;
            GetComponent<Rigidbody2D>().gravityScale = -0.1f;
            
        }
    }
}
