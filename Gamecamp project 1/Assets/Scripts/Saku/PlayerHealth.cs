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
	
	/*int deathreason checks if player died by monsters or by falling to gap to know how to work out with SpawnOnCLick.
	 0 = monsters or if wanted to damage player 1 point of health.
	 1 = Gap or Instant death.
	*/
	public void DisplayHealth (int DeathReason){

		if(DeathReason == 0){
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
		else if (DeathReason == 1){
			Heart3.enabled = false;
			Heart2.enabled = false;
			Heart1.enabled = false;
			CurrentHealth = MaxHealth;
			gameObject.GetComponent<PlayerController2>().isDead = true;
			gameObject.GetComponent<PlayerController2>().Die();
		}

	}

	/**Method to player lose health 1 point.
	After losing health DisplayHealth is called for displaying hearts at canvas.
	 */
	public void LoseHealth (){

		if (CurrentHealth <= 3 && CurrentHealth > 0 && InvulnerabilityTimer == 0){
			CurrentHealth--;
			Debug.Log("Ouch");
			DisplayHealth(0);
            InvulnerabilityTimer = 10;
		}

	}

	/**Made for if wanted to player gain health.
	Not Used yet.
	 */
	public void GainHealth () {

		if (CurrentHealth < 3){
			CurrentHealth++;
			DisplayHealth(0);
		}

	}

	//DeathCanvas. Player spawn on click.
	public void SpawnOnClick (){
		gameObject.GetComponent<PauseMenu>().deathcanvas.gameObject.SetActive (false);
		gameObject.GetComponent<PlayerController2>().disablePlayerMovement(false);
		gameObject.GetComponent<PlayerController2>().isDead = false;
		gameObject.GetComponent<PlayerController2>().Die();
		Time.timeScale = 1;
	}
}
