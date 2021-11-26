using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAttack : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;

    public GameObject attackPoint;

    [Header("Testing")]
    public bool testAttack = false;
    public Sprite attackSprite, idleSprite;
    private SpriteRenderer sr;

    public Animator anim;


    private void Update()
    {
        if (testAttack)
        {
            testAttack = false;
            Attack();
        }
    }

    public void Attack()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(ChargeAndSlash());
    }

    private IEnumerator ChargeAndSlash()
    {
        //this is just for testing, switch it with the real animation when ready
        transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();

        yield return new WaitForSeconds(2f);

        transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Stop();

        anim.SetTrigger("Slash");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.transform.position, 15f, playerLayer);

        foreach (Collider2D c in colliders)
        {
            Debug.Log("Hit Player");
            GetComponent<HurtPlayer>().Hurt(c);
        }

        yield return new WaitForSeconds(1.5f);

       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.25f);
        Gizmos.DrawWireSphere(attackPoint.transform.position, 8f);
    }
}
