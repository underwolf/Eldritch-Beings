using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
