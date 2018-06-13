using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarsPuzzle : MonoBehaviour {

    public Material Cmaterial;
    public Material Wmaterial1;

    public GameObject Bridge;
    public GameObject Pillar1;

    bool state;
    int cooldown;


	// Use this for initialization
	void Start () {
        state = false;
        cooldown = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (cooldown > 0) {
            cooldown--;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("siltaan tormatty");

        if (state == false && cooldown == 0) {
            Bridge.GetComponent<Renderer>().material = Cmaterial;
            Pillar1.GetComponent<Renderer>().material = Cmaterial;
            state = true;
            cooldown = 100;
        }
        else if (state == true && cooldown == 0) {
            Bridge.GetComponent<Renderer>().material = Wmaterial1;
            Pillar1.GetComponent<Renderer>().material = Wmaterial1;
            state = false;
            cooldown = 600;
        }
    }
}
