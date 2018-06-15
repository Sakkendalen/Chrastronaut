 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public Transform canvas;
         
	public bool isPaused;

    public void Update () {
 
        if (Input.GetKeyDown (KeyCode.Escape)) {
            
            if (canvas.gameObject.activeInHierarchy == false) {  
                canvas.gameObject.SetActive (true);
                Time.timeScale = 0;
                isPaused = true;
            } else 
            {
                canvas.gameObject.SetActive (false);
                Time.timeScale = 1;
                isPaused = false;
            }
        }
    }
    
}