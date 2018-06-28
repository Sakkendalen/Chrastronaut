using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour {

    public GameObject Player;
    public GameObject Camera;
    bool ElevatorOn;

	// Use this for initialization
	void Start () {
        ElevatorOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (ElevatorOn) {
            transform.Translate(Vector3.down * 0.1f);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        Player.transform.SetParent(transform.GetChild(0) );
        Camera.GetComponent<CameraFollow2>().lookPlayer = true;
        ElevatorOn = true;
    }
}
