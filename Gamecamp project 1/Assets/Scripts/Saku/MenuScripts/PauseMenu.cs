 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public Transform menucanvas;
    public Transform helpCanvas;
    public Transform deathcanvas;
	public bool isPaused;

    void Awake(){
        isPaused = false;
        Time.timeScale = 1;
    }

    public void Update () {

        if (Input.GetKeyDown (KeyCode.Escape)) {
            if (menucanvas.gameObject.activeInHierarchy == false && helpCanvas.gameObject.activeInHierarchy == false) {  
                menucanvas.gameObject.SetActive (true);
                isPaused = true;
                Time.timeScale = 0;
            } else {
                menucanvas.gameObject.SetActive (false);
                helpCanvas.gameObject.SetActive (false);
                isPaused = false;
                Time.timeScale = 1;
            }
        } else if (gameObject.GetComponent<PlayerController2>().isDead == true){
            deathcanvas.gameObject.SetActive (true);
            Time.timeScale = 0;
            isPaused = true;
        }
    }
    public void disablepausemenu(){
        menucanvas.gameObject.SetActive (false);
        helpCanvas.gameObject.SetActive (false);
        isPaused = false;
        Time.timeScale = 1;
    }
}