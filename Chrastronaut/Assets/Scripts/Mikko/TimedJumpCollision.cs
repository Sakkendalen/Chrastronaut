using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedJumpCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 700f));
    }
}
