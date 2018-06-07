using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {

    Rigidbody2D rigidBody;
    DistanceJoint2D graplingHook;
    Animator animator;
    public Camera gameCamera;
    public GameObject fist;
    float movementx;
    float movementy;
    RaycastHit2D hit;
    public float hookMaxDistance;
    Vector3 mousePosition;
    bool isTouchingGround;
    bool walkleft;
    bool idle;
    public Vector2 CheckpoinPosition;
    Vector2 startposition;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        graplingHook = GetComponent<DistanceJoint2D>();
        animator = GetComponentInChildren<Animator>();
        graplingHook.enabled = false;
        GetComponent<LineRenderer>().material.mainTextureScale = new Vector2(4f, 1f); //linerenderer tekstuurisuhde kun tilet
        isTouchingGround = false;
        walkleft = false;
        idle = false;
        startposition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        checkGround();
        movementForces();
        hookControls();
        drawLines();
        animations();
    }


    public void hookHasJustBegun() {    //called by Fist
        graplingHook.distance = Vector2.Distance(transform.position, fist.transform.position);
    }

    void movementForces() {
        movementx = Input.GetAxis("Horizontal");    //MOVEMENT
        movementy = Input.GetAxis("Vertical");
        if (graplingHook.enabled == false) {    //movement kun maassa

            if (movementx > 0 && rigidBody.velocity.x < 3) {    //kävelynopeuden rajoittimet
                rigidBody.AddForce(new Vector2(movementx * 10, 0));
            }
            if (movementx < 0 && rigidBody.velocity.x > -3) {   //kävelynopeuden rajoittimet
                rigidBody.AddForce(new Vector2(movementx * 10, 0));
            }
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround) {          //HYPPY
            rigidBody.AddForce(new Vector2(0, 200));
            isTouchingGround = false;
        }
        if (Input.GetButtonDown("Jump") && fist.GetComponent<Fist2>().GetState() == 4) { //jos painetaan hyppyä ilmassa irrotetaan koukku
            fist.GetComponent<Fist2>().SetFistState(3);
        }

    }

    void hookControls() {
        mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(gameCamera.transform.position.z); //Laitetaan mousen koordinaatteja maailmaan
        //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition = gameCamera.ScreenToWorldPoint(mousePosition);
        //Debug.Log(" X : " + mousePosition.x + " Y : " + mousePosition.y);


        if (graplingHook.enabled == true) {
            rigidBody.AddForce(new Vector2(movementx * 2, 0));
            graplingHook.distance -= movementy * 0.03f;
            if (graplingHook.distance < 1f) {
                graplingHook.distance = 1f;
            }
            if (graplingHook.distance > 7f) {
                graplingHook.distance = 7f;
            }
            //graplingHook.distance -= 0.05f; //automaattikelaus jos sellainen halutaas
        }

        //if (Input.GetButtonDown("Jump")) {          //HYPPY
        //    rigidBody.AddForce(new Vector2(0, 500f));
        //}

        if (fist.GetComponent<Fist2>().GetState() == 4) { //Jos hook on toiminnassa
            graplingHook.enabled = true;
            graplingHook.connectedAnchor = fist.transform.position;

            GetComponent<CircleCollider2D>().enabled = false;
            hit = Physics2D.Raycast(transform.position, fist.transform.position - transform.position, 7.5f); //tarkastellaan näköyhteyttä
            GetComponent<CircleCollider2D>().enabled = true;
            if (hit.collider.gameObject.name != "Fist") {   //chekataan että se on fist johon on näkö, ja jos on muuta niin disable
                fist.GetComponent<Fist2>().SetFistState(3); //vetää hookin takaisin
            }

        }
        else {
            graplingHook.enabled = false;
        }


        if (Input.GetButtonDown("Fire1") && fist.GetComponent<Fist2>().GetState() == 1) {
            GetComponent<CircleCollider2D>().enabled = false;                                       //RAYCASTI KOHTEESEEN
            //hit = Physics2D.Raycast(transform.position, new Vector2(rigidBody.velocity.x, 5f), 7f);//Vaihtoehtoinen velocityohjaus
            //hit = Physics2D.Raycast(transform.position, new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2), 7f);//vaihtoehtoinen hiiriohjaus
            hit = Physics2D.Raycast(transform.position, mousePosition - transform.position, 7f);    //mousekontrollin kolmas versio joka saattaa jopa toimia

            GetComponent<CircleCollider2D>().enabled = true;                                        //RAYCASTI KOHTEESEEN
            //Debug.Log("mouse X : " + Input.mousePosition);

            if (hit.collider != null) {
                fist.GetComponent<Fist2>().SetFistTarget(new Vector2(hit.point.x, hit.point.y));
                fist.GetComponent<Fist2>().SetFistState(2);
            }
            else {
                //Ray2D ray = new Ray2D(transform.position, new Vector2(rigidBody.velocity.x, 5f)); //vaihtopehtoinen velocityohjaus
                //Ray2D ray = new Ray2D(transform.position, new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2));    //hiiriohjaus
                Ray2D ray = new Ray2D(transform.position, mousePosition - transform.position);
                ray.GetPoint(7f);
                fist.GetComponent<Fist2>().SetFistState(2);
                fist.GetComponent<Fist2>().SetFistTarget(new Vector2(ray.GetPoint(7f).x, ray.GetPoint(7f).y));
            }
        }

        if (Input.GetButtonDown("Fire1") && fist.GetComponent<Fist2>().GetState() == 4) {
            fist.GetComponent<Fist2>().SetFistState(3);
        }
    }

    void drawLines() {
        GetComponent<LineRenderer>().SetPosition(1, transform.position);
        GetComponent<LineRenderer>().SetPosition(0, fist.transform.position);
    }

    void animations() {
        //ANIMAATIOJUTTUJA
        //if (rigidBody.velocity.x > 0.01f || rigidBody.velocity.x < -0.01f) {    //jos nopeus on suurempi kuin niin walk
        //    animator.SetBool("walk", true);
        //}
        //else {
        //    animator.SetBool("walk", false);
        //}


        if (rigidBody.velocity.x < 0f) {         //rotate facing riippuen onko velocity - vai +
            //transform.GetChild(0).gameObject.transform.eulerAngles = new Vector3(0, 270, 0);
            walkleft = true;
            idle = false;
        }
        else if (rigidBody.velocity.x > 0f) {
            //transform.GetChild(0).gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
            walkleft = false;
            idle = false;
        }
        else {
            idle = true;
        }
        animator.speed = 1 + rigidBody.velocity.magnitude / 5;
        animator.SetBool("left", walkleft);
        animator.SetBool("idle", idle);
        animator.SetBool("ground", isTouchingGround);
        //Debug.Log("left : " + walkleft +" ground : " +isTouchingGround +" idle : " +idle);  //ANIMAATIODEBUGGI
        //Debug.Log("left : " + walkleft +" ground : " +isTouchingGround +" idle : " +idle);
    }

    void checkGround() {
        //Vector2 rayOrigin = GetComponent<CircleCollider2D>().bounds.center;

        float rayDistance = GetComponent<CircleCollider2D>().bounds.extents.y + 0.1f;

        if (Physics2D.Raycast(transform.position + new Vector3 (0, -rayDistance, 0) , Vector2.down, 0.1f ) ) {
            isTouchingGround = true;
        }
        else {
            isTouchingGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {

            if (transform.position.y > collision.gameObject.transform.position.y  +0.5f) {
                rigidBody.AddForce(Vector2.up * 500);
                Debug.Log("tapoin vihollisen");
                Destroy(collision.gameObject);
            }
            else {
                Debug.Log("vihollinen gyökkää");
                rigidBody.AddForce(new Vector2(400 * (transform.position.x - collision.gameObject.transform.position.x), 100f ));
            }
        }
    }
            
    public void Die() {
        if(CheckpoinPosition != null){
            transform.position = CheckpoinPosition;
        }
        else{
            transform.position = startposition;
        }
    }
}
