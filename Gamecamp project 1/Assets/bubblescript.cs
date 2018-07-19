using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubblescript : MonoBehaviour {

    Vector3 startpos;

	// Use this for initialization
	void Start () {
        startpos = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
        if ( transform.position.y > 10f) {
            transform.position = new Vector3(startpos.x, -6f , startpos.z);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Kuplatörmäys");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Kuplatörmäys2");
        if (collision.tag != "Zoomer") {
            GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        Debug.Log("Kuplatörmäys3");
        if (collision.tag != "Zoomer") {
            GetComponent<Rigidbody2D>().gravityScale = -0.1f;
        }
    }
}
