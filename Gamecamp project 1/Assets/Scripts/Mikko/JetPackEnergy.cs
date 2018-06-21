using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetPackEnergy : MonoBehaviour {

    public Image jetPackEnergyBar;
    public float maxEnergy;
    public float jetPackPower;
    private float currentEnergy;
    Rigidbody2D rb;

    public GameObject JetPackSound;
    int SoundCooldown;


    //public GameObject smokeSpawnPoint;
    public GameObject smoke;
    ParticleSystem pasy;
    //Vector3 customPosition;

	// Use this for initialization
	void Start () {
        currentEnergy = maxEnergy;
        rb = GetComponent<Rigidbody2D>();
        pasy = smoke.GetComponent<ParticleSystem>();
        //customPosition = new Vector3(0, 0 ,0);
        pasy.enableEmission = false;
        SoundCooldown = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //customPosition.x = rb.velocity.x /10f; //asetellaan partikkeleita kohdalleen velocityn mukaan
        //customPosition.y = rb.velocity.y /10f;

        if ( SoundCooldown > 0) {
            SoundCooldown--;
        }

        jetPackEnergyBar.rectTransform.localScale = new Vector3(currentEnergy / maxEnergy, 1, 1);

        if (Input.GetButton("Jump") && currentEnergy >= 1) {          //HYPPY
            rb.AddForce(new Vector2(0, jetPackPower));
            currentEnergy--;
            pasy.enableEmission = true;


            if (SoundCooldown == 0) {
               Instantiate(JetPackSound, transform.position, transform.rotation);
                SoundCooldown = Random.Range(10, 25);
            }

            //Instantiate(smoke, smokeSpawnPoint.transform.position +customPosition, transform.rotation);
        }
        else {
            pasy.enableEmission = false;

            if (SoundCooldown == 0 && Input.GetButton("Jump")) {
                Instantiate(JetPackSound, transform.position, transform.rotation);
                //SoundCooldown = 30; //hitaampi äänispawnaus
                SoundCooldown = Random.Range(25, 40);
            }

        }

        //if (Input.GetButtonDown("Jump")) {
        //    GetComponent<AudioSource>().Play();
        //}
        //if (Input.GetButtonUp("Jump")) {
        //    GetComponent<AudioSource>().Stop();
        //}


        if (currentEnergy < maxEnergy) {
            currentEnergy += 0.5f;
        }
    }
}
