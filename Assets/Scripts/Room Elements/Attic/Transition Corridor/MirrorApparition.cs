using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class MirrorApparition : MonoBehaviour
{
    private GameObject player;
    private SpriteRenderer sr;
    private BoxCollider2D bc2d;

    public Sprite realReflection, corruptedReflection;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        sr = GetComponent<SpriteRenderer>(); ;
        sr.sprite = realReflection;
        bc2d = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        transform.position = new Vector2(player.transform.position.x - 3f, player.transform.position.y);

        if(player.GetComponent<PlayerMovement>().speed > 0.05f)
        {
            sr.flipX = false;
        }

        if(player.GetComponent<PlayerMovement>().speed < -0.05f)
        {
            sr.flipX = true;
        }
    }

    public void SwapSprite()
    {
        sr.sprite = corruptedReflection;
    }
}
