using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private bool inMotion;
    public GameObject initialPosition;
    public GameObject finalPosition;
    private float lerpTime = 3f;
    public bool arrivedRight;
    public bool isActive;

    private void Start()
    {
        arrivedRight = false;
        inMotion = false;
        isActive = false;
        //initialPosition = transform.position;
    }

    private void Update()
    {
        if (isActive)
        {
            if (!inMotion)
            {
                if (arrivedRight)
                    StartCoroutine(LerpPosition(initialPosition.transform.position, lerpTime));
                else
                    StartCoroutine(LerpPosition(finalPosition.transform.position, lerpTime));
            }
        }
        
    }

    IEnumerator LerpPosition(Vector2 targetPosition, float duration)
    {
        float time = 0;
        Vector2 startPosition = transform.position;
        inMotion = true;

        while(time < duration)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        arrivedRight = !arrivedRight;
        inMotion = false;
        transform.position = targetPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
