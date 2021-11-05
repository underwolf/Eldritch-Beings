using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TutorialDoorSeal : Interactable
{
    SpriteRenderer sr;
    public int id;
    public int timesInteracted;

    private string fungusMessage = "enableTutorial";
    private string fungusMessage2 = "enableTutorial3";
    public Flowchart flowchart;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(0, 0, 0, 0);
        timesInteracted = 0;
    }

    public override void Interact()
    {
        timesInteracted++;
        if(id == 1 && timesInteracted == 1)
        {
            flowchart.SendFungusMessage(fungusMessage);
        }

        if (id == 0 && timesInteracted == 1)
        {
            flowchart.SendFungusMessage(fungusMessage2);
        }

        StartCoroutine(CreateSeal());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player" || collision.tag == "Bullet")
        {
            Interact();
        }
    }

    private IEnumerator CreateSeal()
    {
        for (float f = 0; f < 1; f += Time.deltaTime / 0.1f)
        {

            sr.color = new Color(0.5f, 0, 1, Mathf.Lerp(0, 0.75f, f));
            yield return null;
        }


        yield return new WaitForSeconds(2f);

        for (float f = 0; f < 1; f += Time.deltaTime / 0.25f)
        {
            sr.color = new Color(0.5f, 0, 1, Mathf.Lerp(0.75f, 0, f));
            yield return null;
        }
    }
}
