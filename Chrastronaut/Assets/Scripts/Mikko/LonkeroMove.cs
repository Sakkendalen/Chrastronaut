using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LonkeroMove : MonoBehaviour {

        float OriginalPositionX;
        float OriginalPositionY;
        Vector3 rotationVector;

        public float MovementRadius;
        public float Speed;

        // Use this for initialization
        void Start() {
            OriginalPositionX = transform.position.x;
            OriginalPositionY = transform.position.y;
            rotationVector = new Vector3(0, MovementRadius, 0);
        }

        // Update is called once per frame
        void Update() {

            rotationVector = Quaternion.Euler(0f, 0f, Speed) * rotationVector;
            //transform.Translate(rotationVector);
            transform.position = new Vector3( OriginalPositionX , OriginalPositionY + rotationVector.y , 0f);
            //GetComponent<Rigidbody2D>().MovePosition(new Vector2(OriginalPositionX, OriginalPositionY + rotationVector.y));

        }
    }