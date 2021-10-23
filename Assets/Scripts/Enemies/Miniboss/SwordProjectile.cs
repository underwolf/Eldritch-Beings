using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class SwordProjectile : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float speed = -14.0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.velocity = new Vector2(0, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //hurting the player is handled by the HurtPlayer Script, this is only to make the projectile stop when hitting an obstacle
        if(collision.tag == "Obstacle")
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            StartCoroutine(FadeOutProjectile());
        }
    }

    private IEnumerator FadeOutProjectile()
    {
        for (float f = 0; f < 2; f += Time.deltaTime)
        {
            sr.color = new Color(1, 1, 1, Mathf.Lerp(1.5f, 0, f));
            yield return null;
        }
        Destroy(gameObject);
    }
}
