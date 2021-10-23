using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtticDoor : Interactable
{
    public string target;
    public GameObject SceneManager;

    public override void Interact()
    {
        if (PlayerPrefs.GetInt("AtticSeal") == 1)
            Debug.Log("What if that thing in the attic escapes? Better not go back");
        else
            SceneManager.GetComponent<ScreenManager>().LoadLevel(target);

        //SceneControl.Transitionplayer(target.transform.position);

    }
}
