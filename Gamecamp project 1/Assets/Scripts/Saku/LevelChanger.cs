using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

	public Animator animator;
	
	private int LevelToLoad;

	bool playerInbound;

	void Awake() {
        playerInbound = false;
    }

	void OnTriggerEnter2D(Collider2D collider) {

		if (collider.CompareTag("Player")){

			playerInbound = true;
			Trigger();
		}
	}

	void Trigger (){
		if (playerInbound == true){
			FadeToNextLevel();
		}
	}

	public void FadeToNextLevel () {
		if(SceneManager.GetActiveScene().buildIndex == 3){
			FadeToLevel(0);
		} else {
			FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}

	public void FadeToLevel(int levelIndex) {

		if(levelIndex == 3){
			LevelToLoad = levelIndex;
		}
		else {
			LevelToLoad = levelIndex;
			animator.SetTrigger("FadeOut");
		}
	}

	public void OnFadeComplete(){

		SceneManager.LoadScene(LevelToLoad);
	}
}
