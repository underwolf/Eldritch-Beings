using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunEntity : MonoBehaviour
{
    public void StunEnemy()
    {
        StartCoroutine(StunSequence());
    }

    private IEnumerator StunSequence()
    {
        GetComponent<CourtyardEntity>().followEnabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(3.5f);

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

        yield return new WaitForSeconds(0.25f);

        GetComponent<CourtyardEntity>().followEnabled = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
