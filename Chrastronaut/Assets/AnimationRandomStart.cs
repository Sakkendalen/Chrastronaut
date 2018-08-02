using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRandomStart : MonoBehaviour {

	float offsetti;

	// Use this for initialization
	void Start () {
		offsetti = Random.Range (0.8f, 1.0f );
		GetComponent<Animator> ().speed = offsetti;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
