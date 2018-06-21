using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoomer : MonoBehaviour {

    public GameObject kamera;
    bool isMeActive;
    public float ZoomOutX;
    public float ZoomOutY;
    public float ZoomOutZ;

	// Use this for initialization
	void Start () {
        isMeActive = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isMeActive) {
            kamera.GetComponent<CameraFollow2>().SetZoomout(ZoomOutX, ZoomOutY, ZoomOutZ);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            isMeActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            isMeActive = false;
        }
    }
}
