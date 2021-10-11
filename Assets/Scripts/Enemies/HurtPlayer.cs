using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public float knockbackValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //do damage idk how that gonna work yet

            var player = collision.GetComponent<ApplyKnockback>();
            player.knockback = knockbackValue;
            player.knockbackCount = player.knockbackLength;

            if (collision.transform.position.x < transform.position.x)
                player.knockFromRight = true;
            else
                player.knockFromRight = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //do damage idk how that gonna work yet

            var player = collision.gameObject.GetComponent<ApplyKnockback>();
            player.knockback = knockbackValue;
            player.knockbackCount = player.knockbackLength;

            if (collision.transform.position.x < transform.position.x)
                player.knockFromRight = true;
            else
                player.knockFromRight = false;
        }
    }

    public void Hurt(Collider2D c)
    {
        if(c.tag == "Player")
        {
            //do damage idk how that gonna work yet

            var player = c.gameObject.GetComponent<ApplyKnockback>();
            player.knockback = knockbackValue;
            player.knockbackCount = player.knockbackLength;

            if (c.transform.position.x < transform.position.x)
                player.knockFromRight = true;
            else
                player.knockFromRight = false;
        }
    }

}
