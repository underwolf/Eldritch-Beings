using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballRadialAttack : MonoBehaviour
{
    public GameObject projectile;
    public Transform attackPosition;

    public int projectileAmount;
    public float radius = 5f;
    public bool testAttack = false;

    private Vector2 startPoint;

    private void Update()
    {
        if (testAttack)
        {
            testAttack = false;
            Attack(projectileAmount);
        }
    }

    public void Attack(int amount)
    {
        projectileAmount = amount;
        StartCoroutine(LerpPosition(attackPosition.position, 2f));
        startPoint = attackPosition.position;
        //StartCoroutine(SpawnProjectiles(amount));
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

        transform.position = targetPosition;

        StartCoroutine(SpawnProjectiles(projectileAmount));
    }

    private IEnumerator SpawnProjectiles(int projectileAmount)
    {
        float angleStep = 360f / projectileAmount;
        float angle = 0f;

        for(int i = 0; i < projectileAmount; i++)
        {
            float projectileDirXposition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYposition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector2 projectileVector = new Vector2(projectileDirXposition, projectileDirYposition);
            Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * projectile.GetComponent<FireballProjectile>().speed;

            GameObject projectileObj = Instantiate(projectile, startPoint, Quaternion.AngleAxis(projectileDirXposition, Vector3.forward));
            projectileObj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

            angle += angleStep;

            yield return new WaitForSeconds(0.1f);
        }

        yield return null;
    }
}
