using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarsPuzzle : MonoBehaviour {

    public Material Cmaterial;
    public Material Wmaterial1;

    public GameObject Switch1;
    public GameObject Switch2;
    public GameObject Pillar1;
    public GameObject Pillar2;
    public GameObject Pillar3;
    public GameObject Pillar4;

    public GameObject FaultyRuins1;
    public GameObject FaultyRuins2;
    public GameObject Bridge1;
    public GameObject Bridge2;

	public GameObject tutorialText;
    public GameObject VisualEffect;
    public GameObject VisualEffect2;

    bool Switch1b;
    bool Switch2b;
    bool Switch3b;
    bool Switch4b;

    bool state;
    int cooldown;


	// Use this for initialization
	void Start () {
        Switch1b = false;
        Switch2b = true;
        Switch3b = false;
        Switch4b = true;
        //state = false;
        cooldown = 0;
        //Pillar3.SetActive(false);
        //Pillar4.SetActive(false);
        //FaultyRuins1.SetActive(true);
        //FaultyRuins2.SetActive(true);
        CheckAnswer();
    }
	
	// Update is called once per frame
	void Update () {
        if (cooldown > 0) {
            cooldown--;
        }
	}

    public void Switch1Pressed() {
        if (cooldown == 0) {
            cooldown = 50;
            Debug.Log("Switch1");
            if (Switch1b == false) {
                Switch1b = true;
                Pillar1.GetComponent<Renderer>().material = Cmaterial;
            }
            else {
                Switch1b = false;
                Pillar1.GetComponent<Renderer>().material = Wmaterial1;
            }
        }
        CheckAnswer();
    }

    public void Switch2Pressed() {
        if (cooldown == 0) {
            cooldown = 50;
            Debug.Log("Switch2");
            bool tmp4 = Switch4b;
            Switch4b = Switch3b;
            Switch3b = Switch2b;
            Switch2b = Switch1b;
            Switch1b = tmp4;

            if (Switch1b) {
                Pillar1.GetComponent<Renderer>().material = Cmaterial;
            }
            else {
                Pillar1.GetComponent<Renderer>().material = Wmaterial1;
            }

            if (Switch2b) {
                Pillar2.GetComponent<Renderer>().material = Cmaterial;
            }
            else {
                Pillar2.GetComponent<Renderer>().material = Wmaterial1;
            }
            if (Switch3b) {
                Pillar3.GetComponent<Renderer>().material = Cmaterial;
            }
            else {
                Pillar3.GetComponent<Renderer>().material = Wmaterial1;
            }
            if (Switch4b) {
                Pillar4.GetComponent<Renderer>().material = Cmaterial;
            }
            else {
                Pillar4.GetComponent<Renderer>().material = Wmaterial1;
            }
        }
        CheckAnswer();
    }

    void CheckAnswer() {
        if (Switch1b && Switch2b && Switch3b && Switch4b) {
            Bridge1.SetActive(true);
            Bridge2.SetActive(true);
            FaultyRuins1.SetActive(false);
            FaultyRuins2.SetActive(false);
			tutorialText.GetComponent<TextMesh>().text = "Hooray";
            VisualEffect.SetActive(true);
            VisualEffect2.SetActive(true);
        }
        else {
            Bridge1.SetActive(false);
            Bridge2.SetActive(false);
            FaultyRuins1.SetActive(true);
            FaultyRuins2.SetActive(true);
            VisualEffect.SetActive(false);
            VisualEffect2.SetActive(false);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("siltaan tormatty");

        if (state == false && cooldown == 0) {
            Bridge.GetComponent<Renderer>().material = Cmaterial;
            Pillar1.GetComponent<Renderer>().material = Cmaterial;
            Pillar3.SetActive(true);
            Pillar4.SetActive(true);
            FaultyRuins1.SetActive(false);
            FaultyRuins2.SetActive(false);
            state = true;
            cooldown = 100;
        }
        else if (state == true && cooldown == 0) {
            Bridge.GetComponent<Renderer>().material = Wmaterial1;
            Pillar1.GetComponent<Renderer>().material = Wmaterial1;

            Bridge1.SetActive(false);
            Bridge2.SetActive(false);
            FaultyRuins1.SetActive(true);
            FaultyRuins2.SetActive(true);
            state = false;
            cooldown = 600;
        }
    } */
}
