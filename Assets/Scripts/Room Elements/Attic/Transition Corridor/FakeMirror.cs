using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeMirror : MonoBehaviour
{
    public GameObject apparition;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "mirrorReal")
        {
            apparition.GetComponent<MirrorApparition>().SwapSprite();
        }
    }
}
