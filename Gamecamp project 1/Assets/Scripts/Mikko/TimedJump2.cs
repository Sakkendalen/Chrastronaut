using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedJump2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0,0, -0.05f), Space.World );

        if (transform.position.z < -8f) {
            transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z +45);
        }

        if (transform.position.z < 4f && transform.position.z > -4f) {
            transform.GetComponentInParent<CapsuleCollider2D>().enabled = true;
        }
        else {
            transform.GetComponentInParent<CapsuleCollider2D>().enabled = false;
        }
	}
}
