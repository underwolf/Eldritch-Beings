using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class RoomManager : MonoBehaviour
{
    private string fungusMessage = "enablePuzzle";
    public GameObject fakeDoor;
    public GameObject wallMonster;
    public GameObject switchL;
    public GameObject switchR;
    public Flowchart flowchart;

    public GameObject player;

    private FakeDoor fakeDoorScript;
    private WallMonsterScript wallMonsterScript;

    public GameObject fakeSwitchL, fakeSwitchR;

    private void Awake()
    {
        switchL.SetActive(false);
        switchR.SetActive(false);
        fakeDoorScript = fakeDoor.GetComponent<FakeDoor>();
        wallMonsterScript = wallMonster.GetComponent<WallMonsterScript>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (fakeDoorScript.timesInteracted == 2)
        {
            fakeDoorScript.timesInteracted++;

            player.GetComponent<PlayerMovement>().isCutscene = true;
            //play dialogue
            flowchart.enabled = true;
            flowchart.ExecuteBlock("NyarlathotepDialogue1");   
        }

        if (!GameObject.Find("CultistPlayer"))
        {
            if (flowchart.GetBooleanVariable("TutorialComplete") && Input.GetKey(KeyCode.E))
            {
                flowchart.SetBooleanVariable("TutorialComplete2", true);
            }

            if (flowchart.GetBooleanVariable("TutorialComplete2"))
            {
                flowchart.SendFungusMessage(fungusMessage);

                player.GetComponent<PlayerMovement>().isCutscene = false;
                fakeSwitchL.SetActive(false);
                fakeSwitchR.SetActive(false);
                switchL.SetActive(true);
                switchR.SetActive(true);

                wallMonsterScript.Activate();
            }
        }

    }
}
