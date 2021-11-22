using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBell : Interactable
{
    public string target;
    public GameObject SceneManager;
    public string currentScene;
    public LoadNewScene loader;

    public UnloadSceneNew unloader;

    private void Start()
    {
        SceneManager = GameObject.Find("SceneManager");
        loader = FindObjectOfType<LoadNewScene>();
    }

    public override void Interact()
    {
        unloader.UnloadSceneNewWithGun(currentScene);
        loader.LoadSceneKeepingGun(target);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Bullet")
        {
            Interact();
            Destroy(collision.gameObject);
        }
    }
}
