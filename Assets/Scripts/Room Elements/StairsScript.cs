using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsScript : MonoBehaviour
{
    public bool isUp;
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");  
    }

    private void Update()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            transform.parent.GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            transform.parent.GetComponent<Collider2D>().enabled = isUp;
        }
    }
}
