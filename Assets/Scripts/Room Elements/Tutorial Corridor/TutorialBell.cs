using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBell : Interactable
{
    public GameObject corridorSeal;
    
    public override void Interact()
    {
        Destroy(corridorSeal);
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
