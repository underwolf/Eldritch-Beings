using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WineCellarDoor : Interactable
{
    public string target;
    public GameObject SceneManager;

    public override void Interact()
    {
        if (PlayerPrefs.GetInt("WineCellarSeal") == 1)
            Debug.Log("I'm still feeling a bit woozy, I'm not sure why...");
        else
            SceneManager.GetComponent<ScreenManager>().LoadLevel(target);

        //SceneControl.Transitionplayer(target.transform.position);

    }
}
