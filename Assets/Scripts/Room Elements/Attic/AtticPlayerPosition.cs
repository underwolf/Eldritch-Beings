using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtticPlayerPosition : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 10f);

    }
}
