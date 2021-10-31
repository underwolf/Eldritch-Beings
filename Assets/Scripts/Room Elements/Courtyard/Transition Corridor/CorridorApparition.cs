using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CorridorApparition : MonoBehaviour
{
    private const float MIN_DISTANCE_FROM_PLAYER = 15.0f;
    private const float MAX_DISTANCE_FROM_PLAYER = 35.0f;

    public float playerDist;
    public float speed = 10.0f;

    private Rigidbody2D rb;
    private GameObject player;
    private SpriteRenderer sr;

    public GameObject detectiveMode;

    public GameObject sceneManager;
    private UIFXManager scaryUIFXScript;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scaryUIFXScript = sceneManager.GetComponent<UIFXManager>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        playerDist = transform.position.x - player.transform.position.x;

        if(playerDist > MIN_DISTANCE_FROM_PLAYER && playerDist < MAX_DISTANCE_FROM_PLAYER)
        {
            StopMoving();
        }
        else
        {
            if(playerDist < MIN_DISTANCE_FROM_PLAYER)
            {
                MoveAwayFromPlayer();
            }

            if(playerDist > MAX_DISTANCE_FROM_PLAYER)
            {
                MoveTowardsPlayer();
            }
        }
    }

    private void MoveAwayFromPlayer()
    {
        sr.flipX = true;
        detectiveMode.GetComponent<SpriteRenderer>().flipX = true;
        speed = 10.0f;
        rb.velocity = new Vector2(speed, 0);
    }

    private void MoveTowardsPlayer()
    {
        sr.flipX = false;
        detectiveMode.GetComponent<SpriteRenderer>().flipX = false;
        speed = 10.0f;
        rb.velocity = new Vector2(-speed, 0);
    }

    private void StopMoving()
    {
        speed = 0.0f;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            scaryUIFXScript.DisableEffects();
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
            
    }
}
