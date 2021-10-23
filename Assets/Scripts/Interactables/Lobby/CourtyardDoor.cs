using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourtyardDoor : Interactable
{
    public string target;
    public GameObject SceneManager;

    public override void Interact()
    {
        if (PlayerPrefs.GetInt("CourtyardSeal") == 1)
            Debug.Log("I'm not going back out there. Those things can't die...");
        else
            SceneManager.GetComponent<ScreenManager>().LoadLevel(target);

        //SceneControl.Transitionplayer(target.transform.position);

    }
}
