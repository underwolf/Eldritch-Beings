using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryDoorSeal : Interactable
{
    SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(0, 0, 0, 0);
    }

    public override void Interact()
    {
        StartCoroutine(CreateSeal());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //change "Untagged" to "Bullet" when bullet gets a tag
        if (collision.tag == "Player" || collision.tag == "Untagged")
        {
            Interact();
        }
    }

    private IEnumerator CreateSeal()
    {
        for (float f = 0; f < 1; f += Time.deltaTime / 0.1f)
        {

            sr.color = new Color(1, 0, 0, Mathf.Lerp(0, 0.75f, f));
            yield return null;
        }


        yield return new WaitForSeconds(2f);

        for (float f = 0; f < 1; f += Time.deltaTime / 0.25f)
        {
            sr.color = new Color(1, 0, 0, Mathf.Lerp(0.75f, 0, f));
            yield return null;
        }
    }
}
