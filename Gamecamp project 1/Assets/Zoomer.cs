using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoomer : MonoBehaviour {

    public GameObject kamera;
    bool isMeActive;
    public float ZoomOutX;
    public float ZoomOutY;
    public float ZoomOutZ;
    int Timer;

	// Use this for initialization
	void Start () {
        isMeActive = false;
        Timer = 60;
	}
	
	// Update is called once per frame
	void Update () {
        if (isMeActive == true) {
            kamera.GetComponent<CameraFollow2>().SetZoomout(ZoomOutX, ZoomOutY, ZoomOutZ);
            Debug.Log("Zoomout Update");
        }

        if (Timer == 0) {
            isMeActive = false;
        }
        else {
            Timer--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            isMeActive = true;
            Debug.Log("OnTriggerEnter?????");
            Timer = 40;
        }
    }

    //private void OnTriggerExit2D(Collider2D collision) {
    //    if (collision.gameObject.tag == "Player") {
    //        //isMeActive = false;
     //       Debug.Log("Miksi exit tapahtuu nyt???");
    //    }
    //}

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            isMeActive = true;
            Debug.Log("STAY ja timerissa oli : " + Timer);
            Timer = 40;
        }
    }
}
