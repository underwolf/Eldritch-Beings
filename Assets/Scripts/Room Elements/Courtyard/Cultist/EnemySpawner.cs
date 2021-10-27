using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject courtyardEntity;
    public List<GameObject> enemiesList = new List<GameObject>();

    private SpriteRenderer sr;
    private GameObject player;
    private bool canSpawn = true;
    private int enemyLimit = 0;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(enemiesList.Count <= enemyLimit && canSpawn)
        {
            canSpawn = false;
            StartCoroutine(SummonEnemy());
        }
    }

    private IEnumerator SummonEnemy()
    {
        var y1 = transform.position.y - sr.bounds.size.y / 2;
        var y2 = transform.position.y + sr.bounds.size.y / 2;

        Vector2 spawnPosition = new Vector2(transform.position.x - 10f, Random.Range(y1, y2));

        GameObject entityObj = Instantiate(courtyardEntity, spawnPosition, Quaternion.identity);
        enemiesList.Add(entityObj);
        entityObj.GetComponent<CultistCourtyardEntity>().target = player.transform;
        entityObj.GetComponent<CultistCourtyardEntity>().enemySpawner = gameObject;

        yield return new WaitForSeconds(8f);

        canSpawn = true;
    }
}
