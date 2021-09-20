using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObject : MonoBehaviour
{
    public GameObject InteractableIcon;

    private Vector2 boxSize = new Vector2(0.1f, 1f);

    //put this in the player script, this is just for testing
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            CheckInteraction();
    }

    public void OpenInteractableIcon()
    {
        InteractableIcon.SetActive(true);
    }

    public void CloseInteractableIcon()
    {
        InteractableIcon.SetActive(false);
    }

    //create interact in player script that calls this
    public void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        if(hits.Length > 0)
        {
            foreach(RaycastHit2D rc in hits)
            {
                if (rc.transform.GetComponent<Interactable>())
                {
                    rc.transform.GetComponent<Interactable>().Interact();
                    return;
                }
            }
        }
    }
}
