using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private int health = 100;
    public bool isHealthy = true;

    public GameObject bossElements;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            health--;
            if(health <= 0)
            {
                isHealthy = false;
                Destroy(bossElements);
            }
        }
    }
}
