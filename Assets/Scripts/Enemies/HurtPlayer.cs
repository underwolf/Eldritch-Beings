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
}
