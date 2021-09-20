using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ApplyKnockback : MonoBehaviour
{
    public float knockback = 0f;
    public float knockbackLength;
    public float knockbackCount = -1.0f;
    public bool knockFromRight;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knockbackLength = 0.2f;
    }

    private void Update()
    {
        if(knockbackCount > 0)
        {
            if (knockFromRight)
            {
                rb.velocity = new Vector2(-knockback, knockback/5);
            }

            if (!knockFromRight)
            {
                rb.velocity = new Vector2(knockback, knockback/5);
            }

            knockbackCount -= Time.deltaTime;
        }
        
    }
}
