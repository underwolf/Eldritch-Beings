using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public float knockbackValue;
    public float amountToDamage=10.0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //do damage idk how that gonna work yet
            FindObjectOfType<HealthPlayer>().DamagePlayer(amountToDamage);
            var player = collision.GetComponent<ApplyKnockback>();
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
            FindObjectOfType<HealthPlayer>().DamagePlayer(amountToDamage);
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
