using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FireballProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 50f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //hurting the player is handled by the HurtPlayer Script, this is only to make the projectile stop when hitting an obstacle
        if (collision.tag == "Obstacle")
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            StartCoroutine(LingerFlames());
        }

        if(collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator LingerFlames()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
