using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAttack : MonoBehaviour
{

    public GameObject chargeStartLeft, chargeStartRight;
    private bool startLeft;
    private Rigidbody2D rb;

    [Header("Testing")]
    public bool testAttack = false;

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
        rb = GetComponent<Rigidbody2D>();
        float position = Random.Range(0f, 1f);

        if(position >= 0.5f)
        {
            StartCoroutine(LerpPosition(new Vector2(chargeStartLeft.transform.position.x, chargeStartLeft.transform.position.y + 13f), 1.5f));
            startLeft = true;
        }
        else
        {
            StartCoroutine(LerpPosition(new Vector2(chargeStartRight.transform.position.x, chargeStartRight.transform.position.y + 13f), 1.5f)) ;
            startLeft = false;
        }

    }

    private IEnumerator LerpPosition(Vector2 targetPosition, float duration)
    {
        float time = 0;

        while (time < duration)
        {
            transform.position = Vector2.Lerp(transform.position, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

       //transform.position = targetPosition;

        StartRun();
    }

    public void StartRun()
    {
        if (startLeft)
        {
            StartCoroutine(Charge(chargeStartRight.transform.position, 7.0f));
        }
        else
        {
            StartCoroutine(Charge(chargeStartLeft.transform.position, 7.0f));
        }
    }

    private IEnumerator Charge(Vector2 targetPosition, float duration)
    {
        transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();

        yield return new WaitForSeconds(2f);

        transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Stop();

        float time = 0;

        while (time < duration)
        {
            transform.position = Vector2.Lerp(transform.position, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        yield return new WaitForSeconds(1.5f);
    }
}
