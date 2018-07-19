using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GapDeath : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D Player){
		Player.gameObject.GetComponent<PlayerHealth>().DisplayHealth(1);
	}
}