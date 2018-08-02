using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GapDeath : MonoBehaviour {

	public GameObject FallSound;

	void OnTriggerEnter2D (Collider2D Player){
		Instantiate (FallSound, transform.position, transform.rotation);
		Player.gameObject.GetComponent<PlayerHealth>().DisplayHealth(1);
	}
}