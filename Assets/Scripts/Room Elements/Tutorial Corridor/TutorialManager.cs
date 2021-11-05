using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TutorialManager : MonoBehaviour
{
    private GameObject player;
    public Flowchart flowchart;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (flowchart.GetBooleanVariable("CutsceneStarted"))
        {
            player.GetComponent<CultistMovement>().isCutscene = true;
        }

        if(!flowchart.GetBooleanVariable("CutsceneStarted"))
        {
            player.GetComponent<CultistMovement>().isCutscene = false;
        }
    }
}
