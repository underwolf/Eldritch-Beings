using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtticDoorCultist : Interactable
{
    public string target;
    public GameObject SceneManager;

    public override void Interact()
    {
        if (PlayerPrefs.GetInt("AtticSeal") == 0)
            GetComponent<BoxCollider2D>().enabled = false;
        else
            SceneManager.GetComponent<ScreenManager>().LoadLevel(target);

        //SceneControl.Transitionplayer(target.transform.position);

    }
}
