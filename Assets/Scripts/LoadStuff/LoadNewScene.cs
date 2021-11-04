using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;
public class LoadNewScene : MonoBehaviour
{

    public void LoadSceneKeepingGun(string scene)
    {
        GameObject.FindObjectOfType<Light2D>().enabled = false;
        GameObject.Find("Player").tag = "test";

        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
    }
}
