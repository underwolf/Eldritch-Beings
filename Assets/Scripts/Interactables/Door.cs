using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public GameObject target;

    public override void Interact()
    {
        SceneControl.Transitionplayer(target.transform.position);
    }
}
