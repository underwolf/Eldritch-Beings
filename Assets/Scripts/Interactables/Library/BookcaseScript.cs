using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookcaseScript : Interactable
{
    public GameObject noteUI;
    public bool isActive = false;

    public override void Interact()
    { 
        if (!isActive)
        {
            noteUI.SetActive(true);
            ShowNote();
        }
        if (isActive)
        {
            HideNote();
        }

        isActive = !isActive;
    }

    private void ShowNote()
    {
        noteUI.GetComponent<MoveUI>().Enable();
    }

    private void HideNote()
    {
        noteUI.GetComponent<MoveUI>().Disable();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<InteractWithObject>().CloseInteractableIcon();

            if (isActive)
            {
                HideNote();
                isActive = false;
            }
        }
    }
}
