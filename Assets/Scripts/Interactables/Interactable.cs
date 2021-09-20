using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactable : MonoBehaviour
{
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    public abstract void Interact();

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.GetComponent<InteractWithObject>().OpenInteractableIcon();
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.GetComponent<InteractWithObject>().CloseInteractableIcon();
    }

}
