using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour {

    public GameObject target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    Rigidbody2D rb;
    Vector3 velocityOffset;
    public bool playerAliveMovement;
    public bool lookPlayer;
    Vector3 desiredPosition;
    Vector3 gamePlayZoomouts;

    void Start() {
        rb = target.GetComponent<Rigidbody2D>();
        Vector3 velocityOffset = new Vector3(0, 0, 0);
        playerAliveMovement = true;
        gamePlayZoomouts = new Vector3(0, 0, 0);
        lookPlayer = false;
    }

    private void FixedUpdate() {
        velocityOffset.z = Mathf.Abs(rb.velocity.x);
        velocityOffset.x = rb.velocity.x * -6f;
        velocityOffset.y = rb.velocity.y * -3f;

        if (playerAliveMovement == false) { //jos pelaaja on kuollut kamera liikkuu näin
            desiredPosition = target.transform.position + offset;
            Debug.Log("Kamera liikkuu ilman velocitya");
        }
        else {                                 //jos pelaaja on elossa kemra liikkuu näin
            desiredPosition = target.transform.position + offset - velocityOffset / 2 +gamePlayZoomouts;
        }

        //desiredPosition = target.transform.position + offset - velocityOffset / 2; //alkuperäinen perusliiktuus

        Vector3 smoothedPosition = Vector3.Slerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        gamePlayZoomouts = gamePlayZoomouts / 1.005f;

        if (lookPlayer) {
            Vector3 newDir = Vector3.RotateTowards(transform.forward , target.transform.position - transform.position, 0.3f *Time.deltaTime, 1f);
            transform.rotation = Quaternion.LookRotation(newDir);
        }

        //transform.LookAt(target);
    }

    public void SetZoomout(float x, float y, float z) {
        gamePlayZoomouts = new Vector3(x, y, z);
        Debug.Log(gamePlayZoomouts);
    }
}
