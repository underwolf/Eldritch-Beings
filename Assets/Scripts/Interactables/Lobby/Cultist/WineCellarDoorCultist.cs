using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WineCellarDoorCultist : Interactable
{
    public string target;
    public GameObject SceneManager;

    public override void Interact()
    {
        if (PlayerPrefs.GetInt("WineCellarSeal") == 0)
            GetComponent<BoxCollider2D>().enabled = false;
        else
            SceneManager.GetComponent<ScreenManager>().LoadLevel(target);

        //SceneControl.Transitionplayer(target.transform.position);

    }
}
