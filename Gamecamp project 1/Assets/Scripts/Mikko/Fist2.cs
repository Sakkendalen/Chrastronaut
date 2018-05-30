using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist2 : MonoBehaviour {

    int state;  //1 rest //2 action //3 return //4 hold
    public Vector2 targetPosition;
    public GameObject playerGameobject;
    

	// Use this for initialization
	void Start () {
        state = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (state == 1) {
            transform.position = playerGameobject.transform.position;
        }
        if (state == 2) {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, 0.5f);
        }
        if (state == 3) {
            transform.position = Vector2.MoveTowards(transform.position, playerGameobject.transform.position, 0.5f);
        }



        if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y)
        {
            Debug.Log("RETURN");
            state = 3;
        }
        if (transform.position.x == playerGameobject.transform.position.x && transform.position.y == playerGameobject.transform.position.y )
        {
            Debug.Log("REST");
            state = 1;
        }


        if (Vector2.Distance(transform.position, playerGameobject.transform.position) > 0.8f) {
            GetComponent<CircleCollider2D>().enabled = true;
        }
        else {
            GetComponent<CircleCollider2D>().enabled = false;
        }

    }

    public void SetFistTarget(Vector2 veku)
    {
        targetPosition = veku;
    }

    public void SetFistState(int num)
    {
        state = num;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") {
            Debug.Log("TRIGGER2D!!!");
            state = 4;
            playerGameobject.GetComponent<PlayerController2>().hookHasJustBegun();
        }
    }

    public int GetState() {
        return state;
    }

}
