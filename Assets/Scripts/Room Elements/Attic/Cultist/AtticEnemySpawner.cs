using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtticEnemySpawner : MonoBehaviour
{
    public GameObject courtyardEntity;
    public List<GameObject> enemiesList = new List<GameObject>();

    private SpriteRenderer sr;
    private GameObject player;
    private bool canSpawn = true;
    private int enemyLimit = 1;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (enemiesList.Count <= enemyLimit && canSpawn)
        {
            canSpawn = false;
            StartCoroutine(SummonEnemy());
        }
    }

    private IEnumerator SummonEnemy()
    {
        Vector2 spawnPosition = transform.position;

        GameObject entityObj = Instantiate(courtyardEntity, spawnPosition, Quaternion.identity);
        enemiesList.Add(entityObj);
        entityObj.GetComponent<CultistCourtyardEntity>().target = player.transform;
        entityObj.GetComponent<CultistCourtyardEntity>().enemySpawner = gameObject;
        entityObj.GetComponent<CultistCourtyardEntity>().jumpEnabled = false;
        entityObj.GetComponent<Rigidbody2D>().gravityScale = 3f;
        entityObj.transform.localScale = new Vector3(2f, 2f);

        yield return new WaitForSeconds(2f);

        canSpawn = true;
    }
}
