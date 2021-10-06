using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;


public class ControlCorridorParameters : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;
    public EventReference fmodEvent;
    [SerializeField]
    [Range(0f, 100f)]
    private float distance;
    private GameObject player;
    public GameObject end;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        instance.start();

    }

    void Update()
    {
        distance = player.transform.position.x - end.transform.position.x;
        if (distance <= 0)
        {
            distance = 0;
        }else if(distance >= 100)
        {
            distance = 100;
        }
        instance.setParameterByName("CorridorDistance", distance);
    }
}
