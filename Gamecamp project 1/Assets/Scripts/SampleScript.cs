using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public float rSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

		transform.Translate(Vector3.forward * moveVertical * Time.deltaTime * speed);
		transform.Rotate(Vector3.up * moveHorizontal * rSpeed);

	}
	void OnTriggerEnter(Collider other) {
		Destroy(other.gameObject);
	}
}
