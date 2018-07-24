using UnityEngine;
using System.Collections;

public class disablepausemenu : MonoBehaviour {



    public void notPausedOnClick(bool notpaused)
    {
        gameObject.GetComponent<PauseMenu>().isPaused = notpaused;
        Time.timeScale = 1;
    }
}
