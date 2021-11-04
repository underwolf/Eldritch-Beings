using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeDoor : Interactable
{
    public GameObject target;
    public int timesInteracted = 0;

    public override void Interact()
    {
        timesInteracted++;
        FindObjectOfType<SceneControl>().Transitionplayer(target.transform.position);
        
    }


}
