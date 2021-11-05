using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TutorialSeal : Interactable
{
    public GameObject exitDoorSeal;

    private string fungusMessage = "enableTutorial2";
    private string fungusMessage2 = "endTutorial";
    public Flowchart flowchart;

    public override void Interact()
    {
        flowchart.SendFungusMessage(fungusMessage2);
        exitDoorSeal.SetActive(false);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (flowchart.GetBooleanVariable("Tutorial1Complete") && Input.GetKey(KeyCode.E))
        {
            flowchart.SetBooleanVariable("Tutorial1Complete", false);
            flowchart.SendFungusMessage(fungusMessage);
        }
    }
}
