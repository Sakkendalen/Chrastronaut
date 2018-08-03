using UnityEngine;
using System.Collections;

/**
This script and method is used in pausemenu continue button to
disable pausemenu and pausemenu canvas.
 */
public class disablepausemenu : MonoBehaviour {

    public void notPausedOnClick()
    {
        GameObject.Find("Player").GetComponent<PauseMenu>().disablepausemenu();
    }
}
