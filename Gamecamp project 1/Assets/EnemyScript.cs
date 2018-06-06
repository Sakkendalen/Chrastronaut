using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public float howFarLeft;
    public float howFarRight;
    public float speed;
    public bool goingLeft;
    int position;

	// Use this for initialization
	void Start () {
        position = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (goingLeft == true) {
            transform.GetChild(0).gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
            transform.Translate(new Vector2(speed/1000f, 0) );
            position--;
        }
        if (goingLeft == false) {
            transform.GetChild(0).gameObject.transform.eulerAngles = new Vector3(0, -90, 0);
            transform.Translate(new Vector2(-speed / 1000f, 0));
            position++;
        }

        if (position > howFarRight) {
            goingLeft = true;
        }
        if (position < howFarLeft) {
            goingLeft = false;
        }

	}
}
