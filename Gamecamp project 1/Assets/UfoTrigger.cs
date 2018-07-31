using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoTrigger : MonoBehaviour {

	bool playerInbound = false;

	public Transform target;

	public float speed;

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.CompareTag("Player")){
			playerInbound = true;
		}
	}

	void Update(){
		if(playerInbound == true){
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		}
	}

	/**void Trigger (){
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
	*/
}
