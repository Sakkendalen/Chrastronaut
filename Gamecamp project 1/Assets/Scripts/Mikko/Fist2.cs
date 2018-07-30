using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist2 : MonoBehaviour {

    int state;  //1 rest //2 action //3 return //4 hold
    public Vector2 targetPosition;
    public GameObject playerGameobject;
    RaycastHit2D seePlayerCheck;
	public GameObject PlatformSound;
	public GameObject KelausSound;


    // Use this for initialization
    void Start () {
        state = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (state == 1)     //REST objekti menee pelaajan locationiin, piilotettaan myös graffat
        {
            transform.position = playerGameobject.transform.position;
            transform.GetChild(0).GetComponentInChildren<MeshRenderer>().enabled = false;
        }
        else {
            transform.GetChild(0).GetComponentInChildren<MeshRenderer>().enabled = true;
        }

        if (state == 2) {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, 0.5f);
        }
        if (state == 3) {  //Return
            transform.position = Vector2.MoveTowards(transform.position, playerGameobject.transform.position, 0.5f);
            GetComponent<CircleCollider2D>().enabled = false;
        }
        if (state == 4) {

        } 




        if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y)
        {
            //Debug.Log("RETURN");
            state = 3;
			Instantiate(KelausSound, transform.position, transform.rotation);
        }
        if (transform.position.x == playerGameobject.transform.position.x && transform.position.y == playerGameobject.transform.position.y )
        {
            //Debug.Log("REST");
            state = 1;
        }


        if (Vector2.Distance(transform.position, playerGameobject.transform.position) > 0.8f && state != 3) {
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
        if (state == 3)
        {
            transform.parent = null;
			Instantiate(KelausSound, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform") {
            Debug.Log("TRIGGER2D!!!");
			//playsound
			Instantiate(PlatformSound, transform.position, transform.rotation);
            state = 4;
            playerGameobject.GetComponent<PlayerController2>().hookHasJustBegun();
            transform.parent = collision.gameObject.transform; //parentoidaan collisioniin jos collisionilla on movementtia

            //playerGameobject.GetComponent<DistanceJoint2D>().connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();    //rigidbodyyn liittämistä
        }
    }

    public int GetState() {
        return state;
    }

}
