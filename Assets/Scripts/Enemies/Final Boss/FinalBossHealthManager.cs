using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossHealthManager : MonoBehaviour
{
    public int health = 120;
    public bool isHealthy = false;

    public GameObject sceneManager;
    public string target;
    private void Start()
    {
        GetComponent<HealthManager>().SetHealth(health);
    }

    private void Update()
    {
        if (GetComponent<HealthManager>().health <= 0){

            sceneManager.GetComponent<ScreenManager>().LoadLevel(target);

            Destroy(gameObject);
        }
    }
}
