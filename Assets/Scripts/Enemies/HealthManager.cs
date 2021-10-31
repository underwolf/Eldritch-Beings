using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health;

    public void SetHealth(int enemyHealth)
    {
        health = enemyHealth;
    }

    public void TakeDamage(int projectileDamage)
    {
        health = health - projectileDamage;
    }
}
