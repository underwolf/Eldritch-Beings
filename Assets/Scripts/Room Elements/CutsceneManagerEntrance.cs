using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CutsceneManagerEntrance : MonoBehaviour
{
    private string fungusMessage = "enableTutorial2";
    private string fungusMessage2 = "endScene";
    public Flowchart flowchart;
    public GameObject reloadStatus;
    public GameObject reloadCanvas;
    public GameObject craftingCanvas;
    public GameObject chamberManager;

    public bool isLoaded;
    public bool checkLoaded;

    private void Start()
    {
        isLoaded = false;
        checkLoaded = true;
    }

    void Update()
    {
        if (flowchart.GetBooleanVariable("cutsceneComplete"))
        {
            reloadCanvas.SetActive(true);
            craftingCanvas.SetActive(true);
        }

        if (flowchart.GetBooleanVariable("cutsceneComplete") && reloadStatus.GetComponent<BulletCounter>().transform.childCount > 0)
        {
            flowchart.SendFungusMessage(fungusMessage);

            flowchart.SetBooleanVariable("cutsceneComplete", false);
        }

        if (checkLoaded)
        {
            for (int i = 0; i < chamberManager.GetComponent<ChamberManager>().chambersEmpty.Length; i++)
            {
                if (chamberManager.GetComponent<ChamberManager>().chambersEmpty[i] == false)
                {
                    isLoaded = true;
                }
            }
        }

        if (isLoaded == true)
        {
            isLoaded = false;
            checkLoaded = false;
            flowchart.SetBooleanVariable("tutorialComplete1", true);
        }

        if (flowchart.GetBooleanVariable("tutorialComplete1"))
        {
            flowchart.SendFungusMessage(fungusMessage2);

            flowchart.SetBooleanVariable("tutorialComplete1", false);
        }
    }
}
