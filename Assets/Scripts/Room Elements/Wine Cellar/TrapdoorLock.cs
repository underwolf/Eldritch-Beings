using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapdoorLock : MonoBehaviour
{
    public GameObject trapdoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            trapdoor.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

}
