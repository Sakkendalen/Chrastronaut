using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public GameObject audio1;
    public GameObject audio2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void PlaySound1() {
        Instantiate(audio1 , transform.position, transform.rotation);
    }
}
