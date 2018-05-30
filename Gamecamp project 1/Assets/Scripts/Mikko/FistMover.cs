using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistMover : MonoBehaviour {

    //public Transform fistTarget;
    public Vector2 possu;

	// Use this for initialization
	void Start () {
        //fistTarget.transform.position = new Vector3(10, 10, 10);
        possu = new Vector2(10, 10);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, possu, 0.5f);
	}

    public void SetFistTarget(float x, float y) {
        //fistTarget = transsu;
        possu = new Vector2(x,y);
    }

    public void SetFistPosition(float x, float y)
    {
        transform.position = new Vector2(x, y);
    }
}
