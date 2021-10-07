using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingObstacle : MonoBehaviour
{
    private float slideAmount = 2f;
    public float lerpTime = 2.5f;
    private float t;
    public bool isOpen;
    private Vector3 initialPosition;
    private bool inMotion;

    private void Start()
    {
        isOpen = false;
        inMotion = false;
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (inMotion)
        {
            if (!isOpen)
                slideUp();
            else
                slideDown();
        }
    }

    public void SlideAction()
    {
        inMotion = true;
    }


    private void slideUp()
    {
        //transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, transform.position.y + slideAmount, 1f));

        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, transform.position.y + slideAmount), lerpTime * Time.deltaTime);
        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);

        if (t > 0.9f)
        {
            t = 0;
            inMotion = false;
            isOpen = true;
        }
    }

    private void slideDown()
    {
        //transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, transform.position.y - slideAmount, 1f));
        transform.position = Vector2.Lerp(transform.position, initialPosition, lerpTime * Time.deltaTime);
        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);

        if (t > 0.9f)
        {
            t = 0;
            inMotion = false;
            isOpen = false;
        }
    }
}
