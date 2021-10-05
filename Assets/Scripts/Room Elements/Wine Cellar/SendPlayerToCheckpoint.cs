using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendPlayerToCheckpoint : MonoBehaviour
{
    public GameObject checkpointManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.transform.position = checkpointManager.GetComponent<CheckpointManager>().currentCheckpoint.transform.position;
        }
    }
}
