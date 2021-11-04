using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WineCellarDoor : Interactable
{
    public string target;
    public string currentScene;
    public GameObject sceneManager;
    public LoadNewScene loader;

    public UnloadSceneNew unloader;

    private void Start()
    {
        sceneManager = GameObject.Find("sceneManager");
        loader = FindObjectOfType<LoadNewScene>();
    }
    public override void Interact()
    {
        if (PlayerPrefs.GetInt("WineCellarSeal") == 1)
        {
            sceneManager.GetComponent<GetRoomText>().SetNote(4);
            sceneManager.GetComponent<LobbyDoorClosed>().DoorClosedDialogue(sceneManager.GetComponent<GetRoomText>().currentNoteText);
        }
        else
        {
            unloader.UnloadSceneNewWithGun(currentScene);
            loader.LoadSceneKeepingGun(target);
        }
            

        //SceneControl.Transitionplayer(target.transform.position);

    }
}
