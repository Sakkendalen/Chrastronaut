using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour {

	public float speed;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        float moveVertical = Input.GetAxis ("Horizontal");
		transform.Translate(Vector3.right * moveVertical * Time.deltaTime * speed);

		if (Input.GetKeyDown ("w")){
            transform.Translate(Vector3.up * 260 * Time.deltaTime, Space.World);
    	}

	}
}

