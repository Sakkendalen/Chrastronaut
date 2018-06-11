using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour {

    public GameObject target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    Rigidbody2D rb;
    Vector3 velocityOffset;

    void Start() {
        rb = target.GetComponent<Rigidbody2D>();
        Vector3 velocityOffset = new Vector3(0, 0, 0);
    }

    private void FixedUpdate() {
        velocityOffset.z = Mathf.Abs(rb.velocity.x);
        velocityOffset.x = rb.velocity.x * -6f;
        velocityOffset.y = rb.velocity.y * -3f; 


        Vector3 desiredPosition = target.transform.position + offset - velocityOffset/2;

        Vector3 smoothedPosition = Vector3.Slerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        //transform.LookAt(target);
    }
}
