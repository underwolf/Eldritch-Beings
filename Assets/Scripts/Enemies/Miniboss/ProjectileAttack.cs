using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject projectile;
    public GameObject projectileWarning;

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
        StartCoroutine(ShowWarning());
        StartCoroutine(SpawnProjectiles());
    }

    private IEnumerator ShowWarning()
    {
        int i = 0;

        foreach (GameObject sword in spawnLocations)
        {
            GameObject warningObj = Instantiate(projectileWarning, new Vector2(spawnLocations[i].transform.position.x,
                spawnLocations[i].transform.position.y - 20f), Quaternion.identity);
            GameObject warningObj1 = Instantiate(projectileWarning, new Vector2(spawnLocations[spawnLocations.Length - i - 1].transform.position.x,
                spawnLocations[spawnLocations.Length - i - 1].transform.position.y - 20f), Quaternion.identity);
            i++;

            yield return new WaitForSeconds(1f);

            Destroy(warningObj);
            Destroy(warningObj1);
        }
    }

    private IEnumerator SpawnProjectiles()
    {
        int i = 0;

        foreach(GameObject sword in spawnLocations)
        {

            if(i == 0)
            {
                yield return new WaitForSeconds(1f);
            }

            GameObject projectileObj = Instantiate(projectile, new Vector3(spawnLocations[i].transform.position.x, spawnLocations[i].transform.position.y, 0),
                Quaternion.identity);
            GameObject projectileObj1 = Instantiate(projectile, new Vector3(spawnLocations[spawnLocations.Length - i - 1].transform.position.x,
                spawnLocations[spawnLocations.Length - i - 1].transform.position.y, 0), Quaternion.identity);
            i++;

            yield return new WaitForSeconds(1f);
        }
    }
}
