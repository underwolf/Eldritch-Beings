using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CultistCourtyardEntity : MonoBehaviour
{
    [Header("Pathfinding")]
    public Transform target;
    public float activateDistance = 500f;
    public float pathUpdateSeconds = 0.5f;

    [Header("Physics")]
    public float speed;
    public float nextWaypointDistance = 3f;
    public float jumpNodeHeightRequirement = 0.8f;
    public float jumpModifier = 0.3f;
    public float jumpCheckOffset = 0.1f;

    [Header("Custom Behavior")]
    public bool followEnabled = true;
    public bool jumpEnabled = true;
    public bool directionLookEnabled = true;
    public GameObject enemySpawner;

    private Path path;
    private int currentWaypoint = 0;
    bool isGrounded = false;
    Seeker seeker;
    Rigidbody2D rb;
    public int health = 3;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        GetComponent<HealthManager>().SetHealth(health);
        speed = 950f;

        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);
    }

    private void FixedUpdate()
    {

        if (TargetInDistance() && followEnabled)
        {
            PathFollow();
        }

        if(GetComponent<HealthManager>().health <= 0)
        {
            if(enemySpawner != null)
            {
                if (enemySpawner.GetComponent<AtticEnemySpawner>() != null)
                    enemySpawner.GetComponent<AtticEnemySpawner>().enemiesList.Remove(gameObject);

                if (enemySpawner.GetComponent<EnemySpawner>() != null)
                    enemySpawner.GetComponent<EnemySpawner>().enemiesList.Remove(gameObject);
            }

            Destroy(this.gameObject);
        }
    }

    private void UpdatePath()
    {
        if (followEnabled && TargetInDistance() && seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    private void PathFollow()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
            return;

        Vector3 startOffset = transform.position - new Vector3(0f, GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset);
        isGrounded = Physics2D.Raycast(startOffset, -Vector3.up, 0.05f);

        //Calculating force and direction of movement
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        if (jumpEnabled && isGrounded)
        {
            if (direction.y > jumpNodeHeightRequirement)
            {
                rb.AddForce(Vector2.up * speed * jumpModifier);
            }
        }

        //Movement
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        //Change direction when moving
        if (directionLookEnabled)
        {
            if (rb.velocity.x > 0.05f)
                transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            else if (rb.velocity.x < -0.05f)
                transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.transform.position) < activateDistance;
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Change to bullet after
        if (collision.tag == "Bullet")
        {
            if (GetComponent<HealthManager>().health > 0)
            {
                GetComponent<StunCultistEntity>().StaggerEnemy();
            }
        }
    }
}
