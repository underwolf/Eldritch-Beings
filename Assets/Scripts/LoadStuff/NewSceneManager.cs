using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;
public class NewSceneManager : MonoBehaviour
{
    public static NewSceneManager newManager;
    bool gameStart;
    public Canvas rendererCanvas;
    public string scenetoLoad;

    private void Awake()
    {
        if (!gameStart)
        {
            newManager = this;
            SceneManager.LoadSceneAsync(scenetoLoad, LoadSceneMode.Additive);
            gameStart = true;
        }
    }
    private void Start()
    {
        rendererCanvas = GetComponent<Canvas>();
        rendererCanvas.worldCamera = Camera.main;
    }

    public void ReloadScene(string sceneToLoad)
    {
        GameObject.FindObjectOfType<Light2D>().enabled = false;
        GameObject.Find("Player").tag = "test";
        UnloadScene(sceneToLoad);

        SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

    }

    private void Update()
    {
        if (rendererCanvas.worldCamera == null)
        {
            rendererCanvas.worldCamera = Camera.main;
        }
    }
    public void UnloadScene(string scenetoUnload)
    {
        
        StartCoroutine(Unload(scenetoUnload));
    }

    IEnumerator Unload(string unloadScene)
    {
        yield return null;

        SceneManager.UnloadSceneAsync(unloadScene);
    }
}
