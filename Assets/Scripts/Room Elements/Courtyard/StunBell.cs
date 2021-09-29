using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunBell : Interactable
{
    public GameObject stunArea;
    private SpriteRenderer sr;

    [SerializeField] LayerMask enemyLayer;

    public override void Interact()
    {
        sr = stunArea.GetComponent<SpriteRenderer>();
        StartCoroutine(CreateStunArea());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "Bullet")
        {
            Interact();
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator CreateStunArea()
    {
        yield return new WaitForSeconds(0.1f);

        stunArea.SetActive(true);
        for (float f = 0; f < 1; f += Time.deltaTime / 0.1f)
        {
            
            sr.color = new Color(0, 0, 1, Mathf.Lerp(0, 0.5f, f));
            yield return null;
        }

        CheckForEnemies();

        yield return new WaitForSeconds(3f);

        for (float f = 0; f < 1; f += Time.deltaTime / 0.25f)
        {
            sr.color = new Color(0, 0, 1, Mathf.Lerp(0.5f, 0, f));
            yield return null;
        }

        stunArea.SetActive(false);
    }

    private void CheckForEnemies()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 15f, enemyLayer);

        foreach(Collider2D c in colliders)
        {
            if (c.GetComponent<StunEntity>())
            {
                c.GetComponent<StunEntity>().StunEnemy();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.25f);
        Gizmos.DrawWireSphere(transform.position, 15f);
    }
}
