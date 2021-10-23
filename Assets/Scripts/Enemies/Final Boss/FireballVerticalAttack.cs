using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballVerticalAttack : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject projectile;
    public GameObject darkProjectile;
    public GameObject projectileWarning;
    public Transform attackPosition;

    public bool testAttack = false;

    private void Start()
    {
        spawnLocations = GameObject.FindGameObjectsWithTag("ProjectileSpawnLocation");
    }

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
        StartCoroutine(LerpPosition(attackPosition.position, 2f));
        StartCoroutine(ShowWarning());
        StartCoroutine(ShowWarningDark());
        StartCoroutine(SpawnProjectiles());
        StartCoroutine(SpawnDarkProjectiles());
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
    }

    private IEnumerator ShowWarning()
    {
        int i = 0;

        foreach (GameObject fireball in spawnLocations)
        {
            GameObject warningObj = Instantiate(projectileWarning, new Vector2(spawnLocations[i].transform.position.x,
                spawnLocations[i].transform.position.y - 20f), Quaternion.identity);

            i++;

            yield return new WaitForSeconds(0.75f);

            Destroy(warningObj);
        }

        i = 5;

        foreach (GameObject fireball in spawnLocations)
        {
            GameObject warningObj = Instantiate(projectileWarning, new Vector2(spawnLocations[i].transform.position.x,
                spawnLocations[i].transform.position.y - 20f), Quaternion.identity);

            i--;

            yield return new WaitForSeconds(0.75f);

            Destroy(warningObj);
        }
    }

    private IEnumerator ShowWarningDark()
    {
        int i = 5;

        foreach (GameObject fireball in spawnLocations)
        {
            GameObject warningObj = Instantiate(projectileWarning, new Vector2(spawnLocations[i].transform.position.x,
                spawnLocations[i].transform.position.y - 20f), Quaternion.identity);

            i--;

            yield return new WaitForSeconds(0.75f);

            Destroy(warningObj);
        }

        i = 0;

        foreach (GameObject fireball in spawnLocations)
        {
            GameObject warningObj = Instantiate(projectileWarning, new Vector2(spawnLocations[i].transform.position.x,
                spawnLocations[i].transform.position.y - 20f), Quaternion.identity);

            i++;

            yield return new WaitForSeconds(0.75f);

            Destroy(warningObj);
        }
    }

    private IEnumerator SpawnProjectiles()
    {
        int i = 0;

        foreach (GameObject fireball in spawnLocations)
        {

            if (i == 0)
            {
                yield return new WaitForSeconds(0.75f);
            }

            GameObject projectileObj = Instantiate(projectile, spawnLocations[i].transform.position, Quaternion.AngleAxis(90f, new Vector3(0, 0, -90f)));

            projectileObj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileObj.GetComponent<FireballProjectile>().speed * -1);

            i++;

            yield return new WaitForSeconds(0.75f);
        }

        i = 5;

        foreach (GameObject fireball in spawnLocations)
        {

            GameObject projectileObj = Instantiate(projectile, spawnLocations[i].transform.position, Quaternion.AngleAxis(90f, new Vector3(0, 0, -90f)));

            projectileObj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileObj.GetComponent<FireballProjectile>().speed * -1);

            i--;

            yield return new WaitForSeconds(0.75f);
        }
    }

    private IEnumerator SpawnDarkProjectiles()
    {
        int i = 5;

        foreach (GameObject fireball in spawnLocations)
        {

            if (i == 5)
            {
                yield return new WaitForSeconds(0.75f);
            }

            GameObject projectileObj = Instantiate(darkProjectile, spawnLocations[i].transform.position, Quaternion.AngleAxis(90f, new Vector3(0, 0, -90f)));

            projectileObj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileObj.GetComponent<FireballProjectile>().speed * -1);

            i--;

            yield return new WaitForSeconds(0.75f);
        }

        i = 0;

        foreach (GameObject fireball in spawnLocations)
        {


            GameObject projectileObj = Instantiate(darkProjectile, spawnLocations[i].transform.position, Quaternion.AngleAxis(90f, new Vector3(0, 0, -90f)));

            projectileObj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileObj.GetComponent<FireballProjectile>().speed * -1);

            i++;

            yield return new WaitForSeconds(0.75f);
        }
    }
}
