using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapAttack : MonoBehaviour
{
    private const float MAX_AIR_TIME = 3.0f;

    private GameObject player;
    private Rigidbody2D rb;
    private Vector2 initialPosition;

    public GameObject projectileWarning;
    public GameObject leapPosition;

    public Animator anim;


    public void Attack()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;

        Ascend();
    }

    private void Ascend()
    {
        StartCoroutine(LerpPosition(new Vector2(transform.position.x, leapPosition.transform.position.y), 2f));
    }

    private IEnumerator LerpPosition(Vector2 targetPosition, float duration)
    {
        float time = 0;

        while(time < duration)
        {
            transform.position = Vector2.Lerp(transform.position, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        LockOnPlayer();
    }

    private void LockOnPlayer()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;

        StartCoroutine(ShowWarning());
        StartCoroutine(LockOn(player, MAX_AIR_TIME));
    }

    private IEnumerator ShowWarning()
    {
        GameObject warningObj = Instantiate(projectileWarning, new Vector2(transform.position.x,
                transform.position.y - 20f), Quaternion.identity);

        float time = 0;

        while (time < MAX_AIR_TIME)
        {
            warningObj.transform.position = new Vector2(transform.position.x, transform.position.y - 20f);
            time += Time.deltaTime;
            yield return null;
        }

        Destroy(warningObj);
    }

    private IEnumerator LockOn(GameObject target, float duration)
    {
        float time = 0;

        while (time < duration)
        {
            transform.position = new Vector2(target.transform.position.x, transform.position.y);
            time += Time.deltaTime;
            yield return null;
        }

        Descend();
    }

    private void Descend()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        anim.SetTrigger("Jump");
        rb.velocity = new Vector2(0, -14f);
    }
}
