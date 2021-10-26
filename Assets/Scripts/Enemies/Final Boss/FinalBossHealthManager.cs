using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossHealthManager : MonoBehaviour
{
    public int health = 100;
    public bool isHealthy = false;

    public void TakeDamage()
    {
        health--;
    }
}
