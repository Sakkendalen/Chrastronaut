using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

	public bool Randomize;

	// Use this for initialization
	void Start () {
		
		GetComponent<AudioSource>().volume = GetComponent<AudioSource>().volume * PlayerPrefs.GetFloat("SFXvolume");

		if (Randomize) {
			GetComponent<AudioSource> ().pitch = Random.Range (0.5f , 1.5f);
		}
    }
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<AudioSource>().isPlaying == false ) {
            Destroy(gameObject);
        }
	}

}
