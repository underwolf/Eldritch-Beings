using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CultistWallMonster : MonoBehaviour
{
    public bool isActive;
    public float speed;
    public float dist;
    private int health = 3;

    private Rigidbody2D rb;
    public GameObject startPosition, limitPosition;

    private void Awake()
    {
        isActive = true;
        rb = GetComponent<Rigidbody2D>();
     
    }

    private void Start()
    {
        speed = 5.0f;
        gameObject.transform.position = startPosition.transform.position;
        GetComponent<HealthManager>().SetHealth(health);
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

        if (GetComponent<HealthManager>().health <= 0)
            Destroy(gameObject);
    }

    public void Activate()
    {
        isActive = true;
        rb.velocity = new Vector2(-speed, 0);
    }

    public void ResetPosition()
    {
        gameObject.transform.position = startPosition.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            StartCoroutine(StaggerSequence());
        }
    }



    private IEnumerator StaggerSequence()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(0.5f);

        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
