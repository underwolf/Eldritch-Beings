using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkingPlatform : MonoBehaviour
{
    private bool isPlayerOnPlatform;
    public GameObject initialPosition;
    public GameObject finalPosition;
    public bool isActive;
    private float lerpTimeSink = 0.15f;
    private float lerpTimeFloat = 1.2f;

    private void Start()
    {
        //initialPosition = transform.position;
        isActive = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerOnPlatform = true;
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerOnPlatform = false;
            collision.collider.transform.SetParent(null);
        }
    }


    private void Update()
    {
        if (isActive)
        {
            if (isPlayerOnPlatform)
                transform.position = Vector2.Lerp(transform.position, finalPosition.transform.position, lerpTimeSink * Time.deltaTime);
            else
                transform.position = Vector2.Lerp(transform.position, initialPosition.transform.position, lerpTimeFloat * Time.deltaTime);
        }
    }

}
