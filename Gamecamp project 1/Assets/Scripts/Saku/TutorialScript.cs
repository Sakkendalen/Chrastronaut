using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
This Class is never used.
this was meant to be used in triggering tutorials panels and disable them
when player does recruited actions in tutorial.
 */
public class TutorialScript : MonoBehaviour {
	
	
    bool triggered;
    public GameObject Canvas;
	bool isShowing;

	void update(){
		if (Input.GetKeyDown("Space")){
			isShowing = !isShowing;
			SetInActive(isShowing);
		}
	}
    void Awake()
    {
        triggered = false;
    }
    // called whenever another collider enters our zone (if layers match)
    void OnTriggerEnter2D(Collider2D collider)
    {
        // check we haven't been triggered yet!
        if ( ! triggered)
        {
            if (collider.gameObject.layer 
                == LayerMask.NameToLayer("Default"))
            {
                triggered = true;
                Canvas.SetActive(true);
				Time.timeScale = 0;
            }
        }
    }
    void SetInActive(bool hide){

		Canvas.SetActive(hide);
		Time.timeScale = 1;
    }
}
