using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTrigger : MonoBehaviour {

	public Animator animator;

	bool playerInbound;
	
	void Awake() {
        playerInbound = false;
    }
	void OnTriggerEnter2D(Collider2D collider) {

		if (collider.CompareTag("Player")){
			playerInbound = true;
			Trigger();
		}
	}
	void Trigger (){
		if (playerInbound == true){
		animator.SetTrigger("Open");
		}
	}
}
