using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbbubbleInstantiator : MonoBehaviour {

    public GameObject bubble;
    float countdown;
    float xmod;

	// Use this for initialization
	void Start () {
        countdown = Random.Range(100f, 300f);
        xmod = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		

        if (countdown > 0) {
			countdown -= 1 * Time.deltaTime * 55f;
        }
        if(countdown <= 0) {
            xmod = Random.Range(-2f, 2f);
            Instantiate(bubble, new Vector3(transform.position.x + xmod ,transform.position.y, transform.position.z), transform.rotation);
            countdown = Random.Range(550f, 850f);
        }

	}
}
