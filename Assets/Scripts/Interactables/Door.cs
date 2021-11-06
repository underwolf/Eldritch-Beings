using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : Interactable
{
    public string target;
    public string currentScene;
    public GameObject managerDeCena;
    public LoadNewScene loader;

    public UnloadSceneNew unloader;
    public bool UsedByCultist;
    private void Start()
    {
        managerDeCena=GameObject.Find("SceneManager");
        loader = FindObjectOfType<LoadNewScene>();
        unloader = FindObjectOfType<UnloadSceneNew>();
        if (GameObject.Find("CultistPlayer"))
        {
            UsedByCultist = true;
        }
        else
        {
            
            UsedByCultist=false;
        }
    }
    public override void Interact()
    {
        if (UsedByCultist)
        {
            Time.timeScale = 1.0f;
            managerDeCena.GetComponent<ScreenManager>().LoadLevel(target);
        }
        else
        {
            if (loader == null || unloader==null || managerDeCena==null)
            {
                managerDeCena = GameObject.Find("SceneManager");
                loader = FindObjectOfType<LoadNewScene>();
                unloader = FindObjectOfType<UnloadSceneNew>();
            }
            loader.LoadSceneKeepingGun(target);
            unloader.UnloadSceneNewWithGun(currentScene);
        }
    }
}
