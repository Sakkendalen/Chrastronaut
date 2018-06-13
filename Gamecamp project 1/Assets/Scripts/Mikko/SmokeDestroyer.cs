using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeDestroyer : MonoBehaviour {

    ParticleSystem pasy;

	// Use this for initialization
	void Start () {
        pasy = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if (pasy.IsAlive() == false) {
            Destroy(gameObject);
        }
	}
}
