using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDownPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime;

    private void Awake()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitTime = 0.5f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if(waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = 0.5f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            effector.rotationalOffset = 0f;
        }
    }
}
