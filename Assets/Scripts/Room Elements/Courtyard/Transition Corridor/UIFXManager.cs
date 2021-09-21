using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFXManager : MonoBehaviour
{
    public float dist;

    public Image scaryUIFX;
    private Color scaryUIFXColor;

    public GameObject corridorApparition;
    public GameObject proximityPoint;
    private GameObject player;

    //this is the distance where the FX start to go up
    public float proximity = 100.0f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scaryUIFXColor = scaryUIFX.color;
    }

    private void Update()
    {
        dist = proximityPoint.transform.position.x - player.transform.position.x;

        //this will regulate the volume of the audio based on proximity
        scaryUIFXColor.a = Mathf.InverseLerp(proximity, 0.0f,
            Vector3.Distance(proximityPoint.transform.position, player.transform.position));

        scaryUIFX.color = scaryUIFXColor;
    }

    //use this function to disable the audio
    //CorridorApparition script calls this when colliding with player
    public void DisableEffects()
    {
        scaryUIFX.enabled = false;
    }
}
