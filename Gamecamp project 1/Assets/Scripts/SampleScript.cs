using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleScript : MonoBehaviour {

	public float speed;
	public float rSpeed;
	[SerializeField]
	private Text _uiText;
	// Use this for initialization

	private int hp = 100;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
		string text = "" + hp;
		_uiText.text = text;
		transform.Translate(Vector3.forward * moveVertical * Time.deltaTime * speed);
		transform.Rotate(Vector3.up * moveHorizontal * rSpeed);
		hp--;

	}
	void OnTriggerEnter(Collider other) {
		Destroy(other.gameObject);
	}
}
