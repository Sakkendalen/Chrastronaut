using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public RawImage Heart1;
	public RawImage Heart2;
	public RawImage Heart3;
    public float MaxHealth;
    private float CurrentHealth;
    Rigidbody2D rb;
    int InvulnerabilityTimer;



    void Start () {
		CurrentHealth = MaxHealth;
        rb = GetComponent<Rigidbody2D>();
        InvulnerabilityTimer = 0;
	}

    void Update() {
        if (InvulnerabilityTimer > 0) {
            InvulnerabilityTimer--;
        }
    }
	
	public void DisplayHealth (){

		if (CurrentHealth == 3){
			Heart3.enabled = true;
			Heart2.enabled = true;
			Heart1.enabled = true;
		}
		else if (CurrentHealth == 2){
			Heart3.enabled = false;
		}
		else if (CurrentHealth == 1){
			Heart2.enabled = false;
		}
		else{
			Heart1.enabled = false;
			CurrentHealth = MaxHealth;
			gameObject.GetComponent<PlayerController2>().isDead = true;
			gameObject.GetComponent<PlayerController2>().Die();
		}

	}
	public void LoseHealth (){

		if (CurrentHealth <= 3 && CurrentHealth > 0 && InvulnerabilityTimer == 0){
			CurrentHealth--;
			Debug.Log("Ouch");
			DisplayHealth();
            InvulnerabilityTimer = 10;
		}

	}

	public void GainHealth () {

		if (CurrentHealth < 3){
			CurrentHealth++;
			DisplayHealth();
		}

	}

	//DeathCanvas player spawn on click.
	public void SpawnOnClick (){
		gameObject.GetComponent<PauseMenu>().deathcanvas.gameObject.SetActive (false);
		gameObject.GetComponent<PauseMenu>().isPaused = false;
		gameObject.GetComponent<PlayerController2>().isDead = false;
		gameObject.GetComponent<PlayerController2>().Die();
		Time.timeScale = 1;
	}
}
