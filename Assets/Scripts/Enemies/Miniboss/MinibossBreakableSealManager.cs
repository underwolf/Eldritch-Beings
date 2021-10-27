using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinibossBreakableSealManager : MonoBehaviour
{
    private int health = 50;
    public bool isHealthy = true;

    public GameObject azathothSeal;
    public GameObject bossElements;
    public GameObject[] platforms;
    public GameObject[] stairs;

    private void Start()
    {
        GetComponent<HealthManager>().SetHealth(health);
    }

    private void Update()
    {
        if(GetComponent<HealthManager>().health <= 0)
        {
            isHealthy = false;

            if (azathothSeal != null)
            {
                if(azathothSeal.GetComponent<WineCellarBreakableSeal>() != null)
                    azathothSeal.GetComponent<WineCellarBreakableSeal>().Activate();

                if (azathothSeal.GetComponent<LibraryBreakableSeal>() != null)
                    azathothSeal.GetComponent<LibraryBreakableSeal>().Activate();
            }
                

            if(platforms != null)
            {
                foreach(GameObject platform in platforms)
                {
                    platform.GetComponent<BoxCollider2D>().enabled = true;
                }
                foreach (GameObject collider in stairs)
                {
                    collider.GetComponent<PolygonCollider2D>().enabled = true;
                }
            }

            Destroy(bossElements);
        }
    }
}
