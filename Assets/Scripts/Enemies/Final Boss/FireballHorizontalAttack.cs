using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballHorizontalAttack : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject projectile;
    public GameObject projectileWarning;
    public Transform attackPosition;

    public bool testAttack = false;

    private void Start()
    {
        spawnLocations = GameObject.FindGameObjectsWithTag("ProjectileSpawnLocationHorizontal");
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
        StartCoroutine(SpawnProjectiles());
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

        GameObject warningObj = Instantiate(projectileWarning, new Vector2(spawnLocations[i].transform.position.x + 20f,
                spawnLocations[2].transform.position.y), Quaternion.identity);

        GameObject warningObj1 = Instantiate(projectileWarning, new Vector2(spawnLocations[i].transform.position.x + 20f,
                spawnLocations[5].transform.position.y), Quaternion.identity);

        GameObject warningObj2 = Instantiate(projectileWarning, new Vector2(spawnLocations[i].transform.position.x + 20f,
                spawnLocations[8].transform.position.y), Quaternion.identity);


        yield return new WaitForSeconds(1f);

        Destroy(warningObj);
        Destroy(warningObj1);
        Destroy(warningObj2);
    }

    private IEnumerator SpawnProjectiles()
    {
        yield return new WaitForSeconds(1f);

        int i = 0;

        int gap = Random.Range(0, 6);

        foreach (GameObject fireball in spawnLocations)
        {

            if (i != gap && i != gap+1 && i != gap + 2)
            {
                GameObject projectileObj = Instantiate(projectile, 
                    new Vector3(spawnLocations[i].transform.position.x, spawnLocations[i].transform.position.y, 0), Quaternion.identity);
                projectileObj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileObj.GetComponent<FireballProjectile>().speed, 0);
            }
            i++;
        }

        yield return null;
    }
}
