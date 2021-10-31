using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;
public class ThunderController : MonoBehaviour
{

    public Image thunderBritghness;
    public float thunderTimer;
    public float nextthunderRandom;
    private Color newColor;
    public float brigthcolor;
    public Light2D ligth;

    private float timer;
    bool isThunder;


    // Start is called before the first frame update
    void Start()
    {
        newColor = thunderBritghness.color;
        newColor.a = 0;
        thunderBritghness.color = newColor;
        timer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        thunderTimer -= Time.deltaTime;

        if (isThunder)
        {
            timer -= Time.deltaTime;
            ligth.intensity = 0.5f;
            brigthcolor = timer;
            newColor.a = brigthcolor;
            thunderBritghness.color = newColor;
            if (brigthcolor <= 0)
            {
                thunderTimer = Random.Range(2, nextthunderRandom);
                isThunder = false;
            }

            return; 
        }
        if (thunderTimer <= 0)
        {
            isThunder = true;
            timer = 1;
            brigthcolor = timer;
            ligth.intensity = timer;
        }
    }
}
