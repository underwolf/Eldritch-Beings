using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WineCellarAzathothSeal : Interactable
{
    public GameObject world;
    public GameObject playerNewPosition;
    private GameObject player;
    public List<GameObject> movingPlatforms = new List<GameObject>();
    public List<GameObject> sinkingPlatforms = new List<GameObject>();

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Interact()
    {
        world.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -180f));
        player.transform.position = playerNewPosition.transform.position;

        foreach (GameObject platform in movingPlatforms)
        {
            platform.transform.position = platform.GetComponent<MovingPlatform>().initialPosition.transform.position;
            platform.GetComponent<MovingPlatform>().isActive = true;
        }

        foreach (GameObject platform in sinkingPlatforms)
        {
            platform.transform.position = platform.GetComponent<SinkingPlatform>().initialPosition.transform.position;
            platform.GetComponent<SinkingPlatform>().isActive = true;
        }
    }
}
