using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController22 : MonoBehaviour {

    Rigidbody2D rigidBody;
    DistanceJoint2D graplingHook;
    Animator animator;
    public GameObject fist;
    float movementx;
    float movementy;
    RaycastHit2D hit;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        graplingHook = GetComponent<DistanceJoint2D>();
        animator = GetComponentInChildren<Animator>();
        graplingHook.enabled = false;
        GetComponent<LineRenderer>().material.mainTextureScale = new Vector2(2f, 1f);
    }
	
	// Update is called once per frame
	void Update () {

        if(PauseMenu.isPaused == false){
            movementx = Input.GetAxis("Horizontal");    //MOVEMENT
            movementy = Input.GetAxis("Vertical");
            if (graplingHook.enabled == false) {
                rigidBody.AddForce(new Vector2(movementx * 10, 0));
            }

            if (graplingHook.enabled == true)
            {
                rigidBody.AddForce(new Vector2(movementx * 2, 0));
                graplingHook.distance -= movementy * 0.03f;
                if (graplingHook.distance < 1f)
                {
                    graplingHook.distance = 1f;
                }
                if (graplingHook.distance > 7f)
                {
                    graplingHook.distance = 7f;
                }
            }

            if (Input.GetButtonDown("Jump")) {          //HYPPY
                rigidBody.AddForce(new Vector2(0, 500f));
            }

            if (fist.GetComponent<Fist2>().GetState() == 4) {
                graplingHook.enabled = true;
                graplingHook.connectedAnchor = fist.transform.position;
            }
            else {
                graplingHook.enabled = false;
            }


            if (Input.GetButtonDown("Fire1") && fist.GetComponent<Fist2>().GetState() == 1 ) {
                GetComponent<CircleCollider2D>().enabled = false;                                       //RAYCASTI KOHTEESEEN
                hit = Physics2D.Raycast(transform.position, new Vector2(rigidBody.velocity.x, 10f), 7f);//RAYCASTI KOHTEESEEN
                GetComponent<CircleCollider2D>().enabled = true;                                        //RAYCASTI KOHTEESEEN

                if (hit.collider != null) {
                    fist.GetComponent<Fist2>().SetFistTarget(new Vector2(hit.point.x, hit.point.y));
                    fist.GetComponent<Fist2>().SetFistState(2);
                }
                else {
                    Ray2D ray = new Ray2D(transform.position, new Vector2(rigidBody.velocity.x, 10f));
                    ray.GetPoint(7f);
                    fist.GetComponent<Fist2>().SetFistState(2);
                    fist.GetComponent<Fist2>().SetFistTarget(new Vector2(ray.GetPoint(7f).x, ray.GetPoint(7f).y));
                }
            }

            if (Input.GetButtonDown("Fire1") && fist.GetComponent<Fist2>().GetState() == 4) {
                fist.GetComponent<Fist2>().SetFistState(3);
            }

                GetComponent<LineRenderer>().SetPosition(1, transform.position);
            GetComponent<LineRenderer>().SetPosition(0, fist.transform.position);


            //ANIMAATIOJUTTUJA
            if (rigidBody.velocity.x > 0.01f || rigidBody.velocity.x < -0.01f) {
                animator.SetBool("walk", true);
            }
            else
            {
                animator.SetBool("walk", false);
            }

        
            if (rigidBody.velocity.x < 0)
            {
                transform.GetChild(0).gameObject.transform.eulerAngles = new Vector3(0, 270, 0);
            }
            if (rigidBody.velocity.x > 0)
            {
                transform.GetChild(0).gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
            }
            animator.speed =  1 + rigidBody.velocity.magnitude/5;

        }
    }

    public void hookHasJustBegun() {
        graplingHook.distance = Vector2.Distance(transform.position, fist.transform.position);
    }
}
