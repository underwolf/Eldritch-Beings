using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalTrophies : Interactable
{
    private SpriteRenderer sr;
    public GameObject trophySprite;
    public Sprite activated, deactivated;

    public int puzzleId;
    public bool isActive = false;

    private void Start()
    {
        sr = trophySprite.GetComponent<SpriteRenderer>();
    }

    public override void Interact()
    {
        if (!isActive)
        {
            sr.sprite = activated;
            GetComponentInParent<LibraryPuzzleManager>().puzzleTrophies.Add(gameObject);
            isActive = !isActive;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "Bullet")
        {
            Interact();
            Destroy(collision.gameObject);
        }
    }

    public void ResetPuzzle()
    {
        isActive = false;
        sr.sprite = deactivated;
    }
}
