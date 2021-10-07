using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : Interactable
{
    public Sprite open, closed;
    private SpriteRenderer sRenderer;
    public bool isOpen;

    public List<GameObject> slidingObstacles = new List<GameObject>();
    public override void Interact()
    {
        if (isOpen)
        {
            sRenderer.sprite = closed;
        }
            
        else
        {
            sRenderer.sprite = open;
        }

        ActivateObstacle();
        isOpen = !isOpen;
    }

    private void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        sRenderer.sprite = closed;
    }

    private void ActivateObstacle()
    {
        foreach(GameObject obstacle in slidingObstacles)
        {
            obstacle.GetComponent<SlidingObstacle>().SlideAction();
        }
    }
}
