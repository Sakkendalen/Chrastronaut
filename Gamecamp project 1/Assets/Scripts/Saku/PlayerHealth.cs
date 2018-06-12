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


	void Start () {
		CurrentHealth = MaxHealth;
        rb = GetComponent<Rigidbody2D>();
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
			Heart3.enabled = false;
			Heart2.enabled = false;
		}
		else{
			Heart3.enabled = false;
			Heart2.enabled = false;
			Heart1.enabled = false;
			CurrentHealth = MaxHealth;
			gameObject.GetComponent<PlayerController2>().Die();
		}

	}
	public void LoseHealth (){

		if (CurrentHealth <= 3 && CurrentHealth > 0){
			CurrentHealth--;
			DisplayHealth();
		}

	}

	public void GainHealth () {

		if (CurrentHealth < 3){
			CurrentHealth++;
			DisplayHealth();
		}

	}
}
