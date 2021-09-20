using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WallMonsterScript : MonoBehaviour
{
    public bool isActive;
    public float speed = 7.0f;
    public float dist;

    private Rigidbody2D rb;
    public GameObject startPosition, limitPosition;

    private void Awake()
    {
        isActive = false;
        rb = GetComponent<Rigidbody2D>();
     
    }

    private void Start()
    {
        gameObject.transform.position = startPosition.transform.position;
    }

    private void Update()
    {
        if (isActive)
            Activate();

        dist = Vector2.Distance(transform.position, limitPosition.transform.position);
        if(dist <= 15.0f)
        {
            ResetPosition();
        }
    }

    public void Activate()
    {
        isActive = true;
        rb.velocity = new Vector2(speed, 0);
    }

    public void ResetPosition()
    {
        gameObject.transform.position = startPosition.transform.position;
    }
}
