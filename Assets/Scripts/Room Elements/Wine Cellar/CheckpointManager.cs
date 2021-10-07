using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public GameObject[] checkpointList;
    public GameObject currentCheckpoint;

    private void Start()
    {
        checkpointList = GameObject.FindGameObjectsWithTag("Checkpoint");

        currentCheckpoint = checkpointList[0];
    }

    public void SetCheckpoint(GameObject checkpoint)
    {
        currentCheckpoint = checkpoint;
    }
}
