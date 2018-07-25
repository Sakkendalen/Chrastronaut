using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatform : MonoBehaviour {

    float OriginalPositionX;
    float OriginalPositionY;
    Vector3 rotationVector;
	Vector3 rotationVector2;

    public float MovementRadiusY;
    public float Speed;

	public float MovementRadiusX;

	// Use this for initialization
	void Start () {
        OriginalPositionX = transform.position.x;
        OriginalPositionY = transform.position.y;
        rotationVector = new Vector3(0, MovementRadiusY, 0);
		rotationVector2 = new Vector3 (MovementRadiusX, 0 , 0);
	}
	
	// Update is called once per frame
	void Update () {

        rotationVector = Quaternion.Euler( 0f, 0f, Speed) * rotationVector;
		rotationVector2 = Quaternion.Euler (0f, 0f, Speed) * rotationVector2;
        //transform.Translate(rotationVector);
        //transform.position = new Vector3( OriginalPositionX , OriginalPositionY + rotationVector.y , 0f);
		GetComponent<Rigidbody2D>().MovePosition(new Vector2(OriginalPositionX + rotationVector2.x , OriginalPositionY + rotationVector.y));

	}
}
