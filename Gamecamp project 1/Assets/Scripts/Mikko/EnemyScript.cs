using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public float howFarLeft;
    public float howFarRight;
    public float speed;
    public bool goingLeft;
    int position;
    Vector3 scaler;

	// Use this for initialization
	void Start () {
        position = 0;
        scaler = new Vector3(1, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {

        scaler = Quaternion.Euler(0, -5, 0) * scaler;
        transform.localScale = transform.localScale + new Vector3(scaler.x/75, -scaler.x / 100, 0);

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
