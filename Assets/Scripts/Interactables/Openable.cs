using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Openable : Interactable
{
    public Sprite open, closed;

    private SpriteRenderer sRenderer;
    public bool isOpen;


    public override void Interact()
    {
        if (isOpen)
            sRenderer.sprite = closed;
        else
            sRenderer.sprite = open;

        isOpen = !isOpen;
    }

    private void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        sRenderer.sprite = closed;
    }
}
