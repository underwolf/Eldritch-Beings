using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBell : Interactable
{
    public string target;
    public GameObject SceneManager;

    public override void Interact()
    {
        SceneManager.GetComponent<ScreenManager>().LoadLevel(target);
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
