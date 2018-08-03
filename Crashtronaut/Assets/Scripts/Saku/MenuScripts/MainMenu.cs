using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {
/**
	public Button [] levelButtons;
*/
	public void Start () {

		Time.timeScale = 1;
/** 
		int levelReached = PlayerPrefs.GetInt ("levelReached", 1);

		for (int i = 0; i < levelButtons.Length; i++){
			if(levelReached < i + 1){
				levelButtons[i].interactable = false;
			}
		}
*/	
	}
}
