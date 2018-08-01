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

    public GameObject enemyDeathParticle;

    public GameObject GunSound;
    public GameObject OuchSound;
    public GameObject TouchGroundSound;
	public GameObject FootStepsSound;
	public GameObject enemyDeathSound;
	float footStepDelay;

    int TouchGroundSoundDelay;
    public bool isDead = false;
    public bool disableMovement;
	// Use this for initialization
	void Start () {
        disableMovement = false;
        rigidBody = GetComponent<Rigidbody2D>();
        graplingHook = GetComponent<DistanceJoint2D>();
        animator = GetComponentInChildren<Animator>();
        graplingHook.enabled = false;
        GetComponent<LineRenderer>().material.mainTextureScale = new Vector2(4f, 1f); //linerenderer tekstuurisuhde kun tilet
        isTouchingGround = false;
        walkleft = false;
        idle = false;
        startposition = transform.position;
        TouchGroundSoundDelay = 0;
		footStepDelay = 0;

    }
	
	// Update is called once per frame
	void Update () {
        //to check if game is paused and player needs to be disabled
        //also when levelchanger fading is started player movement had to be disabled
        if (disableMovement == false){
            checkGround();
            movementForces();
            hookControls();
            drawLines();
            animations();

            if (transform.position.y < -10) {  //rotkokuolema
                //Die();
            }
            if ( TouchGroundSoundDelay > 0) {
                TouchGroundSoundDelay--;
            }
			if (!idle && isTouchingGround && footStepDelay < 1) { //walk sound play
                if(isDead == false){
				    Instantiate (FootStepsSound, transform.position, transform.rotation);
                }
				footStepDelay = Random.Range (28f, 34f);
			} 
			if (footStepDelay > 0) {
				footStepDelay = footStepDelay - Mathf.Abs(rigidBody.velocity.x/5f ) -1f;
			}

            //paskafixi maan kaltevuuteen alkaa
            GetComponent<CircleCollider2D>().enabled = false;
            RaycastHit2D hitdown;
            hitdown = Physics2D.Raycast(transform.position , Vector2.down, 1f);
            //Debug.Log(" Normal : " + hitdown.normal);
            GetComponent<CircleCollider2D>().enabled = true;
            if (hitdown.normal.x < -0.1f) {
                //Debug.Log("extraforce right");
                rigidBody.AddForce(Vector2.left * hitdown.normal.x * 7f);
            }
            if (hitdown.normal.x > 0.1f) {
                //Debug.Log("extraforce left");
                rigidBody.AddForce(Vector2.left * hitdown.normal.x * 7f);
            }
            //loppuu

            //Debug.Log(" X " + movementx + "    Y " + movementy);
            Debug.DrawRay(transform.position, new Vector3 (movementx *5, movementy *5, 0f), Color.green);
        }

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
            TouchGroundSoundDelay = 15;
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


        if ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire1J")) && fist.GetComponent<Fist2>().GetState() == 1) {
            GetComponent<CircleCollider2D>().enabled = false;                                       //RAYCASTI KOHTEESEEN
            //hit = Physics2D.Raycast(transform.position, new Vector2(rigidBody.velocity.x, 5f), 7f);//Vaihtoehtoinen velocityohjaus
            //hit = Physics2D.Raycast(transform.position, new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2), 7f);//vaihtoehtoinen hiiriohjaus
            if (Input.GetButtonDown("Fire1")) {
                hit = Physics2D.Raycast(transform.position, mousePosition - transform.position, 7f);    //mousekontrollin kolmas versio joka saattaa jopa toimia
                //Debug.Log("HiiriFire");
            }
            if (Input.GetButtonDown("Fire1J")) {
                hit = Physics2D.Raycast(transform.position, new Vector3(movementx , movementy, 0f), 7f);    //mousekontrollin kolmas versio joka saattaa jopa toimia
                Debug.Log("JoiskaFire");
            }

            if(isDead == false){
                Instantiate(GunSound, transform.position, transform.rotation); //gun sound
            }


            GetComponent<CircleCollider2D>().enabled = true;                                        //RAYCASTI KOHTEESEEN
            //Debug.Log("mouse X : " + Input.mousePosition);

            if (hit.collider != null) {
                fist.GetComponent<Fist2>().SetFistTarget(new Vector2(hit.point.x, hit.point.y));
                fist.GetComponent<Fist2>().SetFistState(2);
            }
            else {
                //Ray2D ray = new Ray2D(transform.position, new Vector2(rigidBody.velocity.x, 5f)); //vaihtopehtoinen velocityohjaus
                //Ray2D ray = new Ray2D(transform.position, new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2));    //hiiriohjaus
                Ray2D ray;
                if (Input.GetButtonDown("Fire1")) {
                     ray = new Ray2D(transform.position, mousePosition - transform.position);
                    ray.GetPoint(7f);
                    fist.GetComponent<Fist2>().SetFistState(2);
                    fist.GetComponent<Fist2>().SetFistTarget(new Vector2(ray.GetPoint(7f).x, ray.GetPoint(7f).y));
                }
                if (Input.GetButtonDown("Fire1J")) {
                    ray = new Ray2D(transform.position, new Vector2(movementx,movementy));
                    ray.GetPoint(7f);
                    fist.GetComponent<Fist2>().SetFistState(2);
                    fist.GetComponent<Fist2>().SetFistTarget(new Vector2(ray.GetPoint(7f).x, ray.GetPoint(7f).y));
                }


                //ray.GetPoint(7f);
                //fist.GetComponent<Fist2>().SetFistState(2);
                //fist.GetComponent<Fist2>().SetFistTarget(new Vector2(ray.GetPoint(7f).x, ray.GetPoint(7f).y));
            }
        }

        if ( (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire1J")) && fist.GetComponent<Fist2>().GetState() == 4) {
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


        if (rigidBody.velocity.x < -0.01f) {         //rotate facing riippuen onko velocity - vai +
            //transform.GetChild(0).gameObject.transform.eulerAngles = new Vector3(0, 270, 0);
            walkleft = true;
            idle = false;
        }
        else if (rigidBody.velocity.x > 0.01f) {
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
        // Debug.Log("left : " + walkleft +" ground : " +isTouchingGround +" idle : " +idle);  //ANIMAATIODEBUGGI
        //Debug.Log("left : " + walkleft +" ground : " +isTouchingGround +" idle : " +idle);
    }




    void checkGround() {
        //Vector2 rayOrigin = GetComponent<CircleCollider2D>().bounds.center;

        float rayDistance = GetComponent<CircleCollider2D>().bounds.extents.y + 0.15f;

        if (Physics2D.Raycast(transform.position + new Vector3 (0, -rayDistance, 0) , Vector2.down, 0.1f ) ) {

            if (isTouchingGround == false && TouchGroundSoundDelay == 0) {    //play touchGroundSound
                if(isDead == false){
                    Instantiate(TouchGroundSound, transform.position, transform.rotation);
                    Debug.Log("groundsound played");
                }
            }

            isTouchingGround = true;
        }
        else {
            isTouchingGround = false;
        }
    }




    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {

            if (transform.position.y > collision.gameObject.transform.position.y + 0.5f) {
                rigidBody.AddForce(Vector2.up * 400);
                Debug.Log("tapoin vihollisen");
				Instantiate(enemyDeathSound, transform.position, transform.rotation);
                Instantiate(enemyDeathParticle, collision.transform.position, collision.transform.rotation);
                Destroy(collision.gameObject);
            }
            else {
                Debug.Log("vihollinen gyökkää");
                rigidBody.AddForce(new Vector2(1.5f * (transform.position.x - collision.gameObject.transform.position.x), 2f), ForceMode2D.Impulse);
                gameObject.GetComponent<PlayerHealth>().LoseHealth();
                //Die();
            }
        }

        if (collision.gameObject.tag == "EnemySpikes") {

            if(isDead == false){
                Instantiate(OuchSound, transform.position, transform.rotation);
            }

            if (transform.position.x < collision.gameObject.transform.position.x) {
                rigidBody.AddForce(new Vector2 (-2f, 2f), ForceMode2D.Impulse);
                gameObject.GetComponent<PlayerHealth>().LoseHealth();
            }
            else {
                rigidBody.AddForce(new Vector2(2, 2f), ForceMode2D.Impulse);
                gameObject.GetComponent<PlayerHealth>().LoseHealth();
            }
            //rigidBody.AddForce(new Vector2(400 * (transform.position.x - collision.gameObject.transform.position.x), 100f));

        }
    }
            
    public void Die() {

        rigidBody.velocity = Vector2.zero;

        if (CheckpoinPosition != null){
            transform.position = CheckpoinPosition;
            gameObject.GetComponent<PlayerHealth>().DisplayHealth(0);
        }
        else{
            transform.position = startposition;
            gameObject.GetComponent<PlayerHealth>().DisplayHealth(0);
        }

        //gameCamera.GetComponent<CameraFollow2>().playerAliveMovement = false; //pelaaja on kuollut ja asetetaan kameran liikkumismoodi sellaiseksi
        //rigidBody.angularVelocity = Vector3.zero;
    }

    /**
    This method will determite is player allowed to move by simply changing bool disableMovement
    which we will check in update method that it is false. This method will elimite one boolean out of
    our code and it will improve little that we do not change public variable in every other scripts and
    reduces confusion of when it will be changed and checked.
     */
    public void disablePlayerMovement(bool disable){
        disableMovement = disable;
    }
}
