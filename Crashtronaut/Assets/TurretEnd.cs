using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnd : MonoBehaviour {

    // have we been triggered?
    bool triggered;

    public GameObject turretParticle;

    void Awake()
    {
        triggered = false;
    }
    // called whenever another collider enters our zone (if layers match)
    void OnTriggerEnter2D(Collider2D collider)
    {
        // check we haven't been triggered yet!
        if (!triggered)
        {
            // check we actually collided with 
            // a character. It would be best to
            // setup your layers so this check is
            // not required, by creating a layer 
            // "Checkpoint" that will only collide 
            // with characters.
            if (collider.gameObject.layer
                == LayerMask.NameToLayer("Default"))
            {
                Trigger(collider.gameObject);
                triggered = true;
                turretParticle.SetActive(true);
            }
        }
    }
    void Trigger(GameObject Player)
    {
        Player.GetComponent<PlayerController2>().CheckpoinPosition = transform.position;
    }
}
