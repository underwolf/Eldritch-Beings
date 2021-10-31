using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtticDoor : Interactable
{
    public string target;
    public GameObject SceneManager;

    public override void Interact()
    {
        if (PlayerPrefs.GetInt("AtticSeal") == 1)
        {
            SceneManager.GetComponent<GetRoomText>().SetNote(3);
            SceneManager.GetComponent<LobbyDoorClosed>().DoorClosedDialogue(SceneManager.GetComponent<GetRoomText>().currentNoteText);
        }
        else
            SceneManager.GetComponent<ScreenManager>().LoadLevel(target);

        //SceneControl.Transitionplayer(target.transform.position);

    }
}
