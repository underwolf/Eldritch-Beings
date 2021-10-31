using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunEntity : MonoBehaviour
{

    public SpriteRenderer[] sprites;
    public int playerLayer, EnemyLayer, numberOfFlahses;
    public Color m_HurtColor;

    public float stunTime = 3.5f, staggerTime = 0.25f;
    public void StunEnemy()
    {
        StartCoroutine(StunSequence());
    }

    private IEnumerator StunSequence()
    {
        GetComponent<CourtyardEntity>().followEnabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(Iframe(stunTime));
        yield return new WaitForSeconds(stunTime);

        GetComponent<CourtyardEntity>().followEnabled = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public void StaggerEnemy()
    {
        StartCoroutine(StaggerSequence());
    }

    private IEnumerator StaggerSequence()
    {
        GetComponent<CourtyardEntity>().followEnabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(Iframe(staggerTime));
        yield return new WaitForSeconds(staggerTime);

        GetComponent<CourtyardEntity>().followEnabled = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    private IEnumerator Iframe(float time)
    {
        Physics2D.IgnoreLayerCollision(playerLayer, EnemyLayer, true);
        for (int i = 0; i < numberOfFlahses; i++)
        {

            foreach (SpriteRenderer sprite in sprites)
            {
                sprite.color = m_HurtColor;
            }
            yield return new WaitForSeconds(time / (numberOfFlahses * 2));
            foreach (SpriteRenderer sprite in sprites)
            {
                sprite.color = Color.white;
            }
            yield return new WaitForSeconds(time / (numberOfFlahses * 2));
        }
        Physics2D.IgnoreLayerCollision(playerLayer, EnemyLayer, false);

    }
}
