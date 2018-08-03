 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public Transform menucanvas;
    public Transform helpCanvas;
    public Transform deathcanvas;
    public Transform audiocanvas;
    public Transform helpGroup;

	//public bool isPaused;

    void Awake(){
        //isPaused = false;
        Time.timeScale = 1;
    }

    public void Update () {

        if (Input.GetKeyDown (KeyCode.Escape)) {
            if (menucanvas.gameObject.activeInHierarchy == false && helpCanvas.gameObject.activeInHierarchy == false
            && audiocanvas.gameObject.activeInHierarchy == false && helpGroup.gameObject.activeInHierarchy == false) {  
                menucanvas.gameObject.SetActive (true);
                //isPaused = true;
                Time.timeScale = 0;
                GameObject.Find("Player").GetComponent<PlayerController2>().disablePlayerMovement(true);

            } else {
                menucanvas.gameObject.SetActive (false);
                audiocanvas.gameObject.SetActive (false);
                helpGroup.gameObject.SetActive (false);
                helpCanvas.gameObject.SetActive (false);
                //isPaused = false;
                Time.timeScale = 1;
                GameObject.Find("Player").GetComponent<PlayerController2>().disablePlayerMovement(false);
            }
        } else if (gameObject.GetComponent<PlayerController2>().isDead == true){
            deathcanvas.gameObject.SetActive (true);
            Time.timeScale = 0;
            //isPaused = true;
            GameObject.Find("Player").GetComponent<PlayerController2>().disablePlayerMovement(true);
        }
    }
    public void disablepausemenu(){
        menucanvas.gameObject.SetActive (false);
        helpCanvas.gameObject.SetActive (false);
        //isPaused = false;
        Time.timeScale = 1;
        GameObject.Find("Player").GetComponent<PlayerController2>().disablePlayerMovement(false);
    }
}