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

	// Use this for initialization
	void Start () {
        currentEnergy = maxEnergy;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        jetPackEnergyBar.rectTransform.localScale = new Vector3(currentEnergy / maxEnergy, 1, 1);

        if (Input.GetButton("Jump") && currentEnergy >= 1) {          //HYPPY
            rb.AddForce(new Vector2(0, jetPackPower));
            currentEnergy--;
        }


        if (currentEnergy < maxEnergy) {
            currentEnergy += 0.5f;
        }
    }
}
