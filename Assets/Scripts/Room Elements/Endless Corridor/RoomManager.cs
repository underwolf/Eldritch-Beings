using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject fakeDoor;
    public GameObject wallMonster;
    public GameObject switchL;
    public GameObject switchR;

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
            //play dialogue
            switchL.SetActive(true);
            switchR.SetActive(true);

            Debug.Log("Hello why don't you try solving the puzzle lmao");

            wallMonsterScript.Activate();
        }
    }
}
