using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject checkpointManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            checkpointManager.GetComponent<CheckpointManager>().SetCheckpoint(this.gameObject);
        }
    }
}
