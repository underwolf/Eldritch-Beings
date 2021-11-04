using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UnloadSceneNew : MonoBehaviour
{

    bool unloaded;

    public void UnloadSceneNewWithGun(string scene)
    {

        NewSceneManager.newManager.UnloadScene(scene);
    }
    
}
