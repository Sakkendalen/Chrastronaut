using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

	public Animator animator;

	bool playerInbound;

	private int LevelToLoad;
	//public int leveltoUnlock;

	//when level is loaded sets automatically that player is not in collidertrigger.
	void Awake() {
        playerInbound = false;
    }

	//Unity own libary script, looks if player is in collider.
	void OnTriggerEnter2D(Collider2D collider) {

		if (collider.CompareTag("Player")){
			playerInbound = true;
			Trigger();
		}
	}

	//plah plah... if player have triggered leveltrigger, disables movement and send FadetoNextLevel command to fade next level
	//also sets leveltoUnlock variable new int to Playerpref know what level player have beaten.
	void Trigger (){
		if (playerInbound == true){
				/**
				if (leveltoUnlock < 3){
					leveltoUnlock = LevelToLoad + 1;
				}
				*/
			GameObject.Find("Player").GetComponent<PlayerController2>().disablePlayerMovement(true);
			FadeToNextLevel();
		}
	}

	//sends Fadetolevel what level needs to be loaded. 3 -> main menu, else automatically next level.
	public void FadeToNextLevel () {
		if(SceneManager.GetActiveScene().buildIndex == 3){
			FadeToLevel(0);
		} else {
			FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}

	//sets what level needs to be loaded. If level 3 then load mainmenu else automatically next level.
	public void FadeToLevel(int levelIndex) {

		if(levelIndex == 3){
			LevelToLoad = levelIndex;
		}
		else {
			//WinLevel();
			LevelToLoad = levelIndex;
			animator.SetTrigger("FadeOut");
		}
	}

	//after fading animation is completed loads next level or mainmenu if last level.
	public void OnFadeComplete(){

		SceneManager.LoadScene(LevelToLoad);
	}
/**
	//sets PlayerPrefs what level have player won to mainmenu know what level buttons needs to be interractable.
	public void WinLevel (){
		PlayerPrefs.SetInt("levelReached", leveltoUnlock);
	}
*/
}
