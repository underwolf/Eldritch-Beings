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

    private FakeDoor fakeDoorScript;
    private WallMonsterScript wallMonsterScript;

    private void Awake()
    {
        switchL.SetActive(false);
        switchR.SetActive(false);
        fakeDoorScript = fakeDoor.GetComponent<FakeDoor>();
        wallMonsterScript = wallMonster.GetComponent<WallMonsterScript>();
    }

    private void Update()
    {
        if (fakeDoorScript.timesInteracted == 2)
        {
            fakeDoorScript.timesInteracted++;
            //play dialogue
            flowchart.enabled = true;
            flowchart.ExecuteBlock("NyarlathotepDialogue1");   
        }

        if (flowchart.GetBooleanVariable("TutorialComplete") && Input.GetKey(KeyCode.E))
        {
            flowchart.SetBooleanVariable("TutorialComplete2", true);
        }

        if (flowchart.GetBooleanVariable("TutorialComplete2"))
        {
            flowchart.SendFungusMessage(fungusMessage);

            switchL.SetActive(true);
            switchR.SetActive(true);

            wallMonsterScript.Activate();
        }
    }
}
