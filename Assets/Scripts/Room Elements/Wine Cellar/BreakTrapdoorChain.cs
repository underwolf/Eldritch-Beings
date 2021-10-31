using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakTrapdoorChain : Interactable
{
    public override void Interact()
    {
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Bullet")
        {
            Interact();
            Destroy(collision.gameObject);
        }
    }
}
