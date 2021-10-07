using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtticAzathothSeal : Interactable
{
    public GameObject exitDoorSeal;

    public override void Interact()
    {
        exitDoorSeal.SetActive(false);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Enemy")
        {
            Interact();
        }
    }
}
