using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SputnikScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0,0, -0.05f), Space.World );

        if (transform.position.z < -20f) {
            transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z +70);
        }

        if (transform.position.z < 5f && transform.position.z > -5f) {
            transform.GetComponentInParent<CapsuleCollider2D>().enabled = true;
        }
        else {
            transform.GetComponentInParent<CapsuleCollider2D>().enabled = false;
        }
	}
}
