using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Animator>().speed = 0f;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        GetComponent<Animator>().speed = 1f;
    }
}
