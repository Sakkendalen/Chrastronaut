using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	public float jumpforce;

	void Start () {
		
		rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
        float moveVertical = Input.GetAxis ("Horizontal");
		transform.Translate(Vector3.right * moveVertical * Time.deltaTime * speed);

		if (Input.GetButton("Jump")){
    		playerJump();
    	}

	}
	void playerJump() {

    Debug.Log ("Should Jump");

    Vector3 rayOrigin = GetComponent<Collider>().bounds.center;

    float rayDistance = GetComponent<Collider>().bounds.extents.y + 0.1f;
    Ray ray = new Ray ();
    ray.origin = rayOrigin;
    ray.direction = Vector3.down;
    if(Physics.Raycast(ray, rayDistance, 1 << 8)) {
        Debug.Log ("Jumping");
        rb.AddForce (Vector3.up * jumpforce, ForceMode.Impulse);
    }
}
}

