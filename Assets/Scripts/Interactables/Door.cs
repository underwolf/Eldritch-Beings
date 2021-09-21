using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public string target;
    public GameObject SceneManager;

    public override void Interact()
    {
        //SceneControl.Transitionplayer(target.transform.position);
        SceneManager.GetComponent<ScreenManager>().LoadLevel(target);
    }
}
