using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossHealthManager : MonoBehaviour
{
    public int health = 100;
    public bool isHealthy = false;

    private void Start()
    {
        GetComponent<HealthManager>().SetHealth(health);
    }

    private void Update()
    {
        if (GetComponent<HealthManager>().health <= 0){
            Destroy(gameObject);
        }
    }
}
