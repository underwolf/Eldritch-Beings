 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class LobbyDoorClosed : MonoBehaviour
{
    public Flowchart flowchart;

    public void DoorClosedDialogue(string roomText)
    {
        flowchart.SetStringVariable("RoomText", roomText);
        flowchart.ExecuteBlock("DoorClosed");
    }
}
