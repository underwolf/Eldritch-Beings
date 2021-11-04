using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CourtyardDoor : Interactable
{
    public string target;
    public string currentScene;
    public GameObject sceneManager;
    public LoadNewScene loader;

    public UnloadSceneNew unloader;
    private void Start()
    {
        sceneManager = GameObject.Find("SceneManager");
        loader = FindObjectOfType<LoadNewScene>();
        unloader = FindObjectOfType<UnloadSceneNew>();
    }
    public override void Interact()
    {
        if (PlayerPrefs.GetInt("CourtyardSeal") == 1)
        {
            sceneManager.GetComponent<GetRoomText>().SetNote(2);
            sceneManager.GetComponent<LobbyDoorClosed>().DoorClosedDialogue(sceneManager.GetComponent<GetRoomText>().currentNoteText);
        }
        else
        {
            loader.LoadSceneKeepingGun(target);
            unloader.UnloadSceneNewWithGun(currentScene);
        }


        //SceneControl.Transitionplayer(target.transform.position);
    }
}
