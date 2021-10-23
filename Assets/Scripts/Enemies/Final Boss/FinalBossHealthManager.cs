using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossHealthManager : MonoBehaviour
{
    public int health = 100;
    public bool isHealthy = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            health--;
            if (health <= 0)
            {
                isHealthy = false;

                //Death Animation
                Destroy(gameObject);
            }
        }
    }
}
