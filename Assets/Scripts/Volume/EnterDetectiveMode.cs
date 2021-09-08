using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class EnterDetectiveMode : MonoBehaviour
{
    public GameObject volumeObject;
    public Volume volume;
    [Header("Times to interpolate")]
    public float tcr, tfg, tld;

    [Header("Clues Color")]
    public Color before, now;

    ChromaticAberration cr;
    FilmGrain fg;

    bool isActive = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
           ActivateVolume();
           SetObjectColors("#00FFFA");
           isActive = true;
        }
        else if(isActive)
        {
            Debug.Log("Desativado");
            DeactivateVolume();
            SetObjectColors("#FDF400");
            isActive = false;

        }

        
    }

    private void DeactivateVolume()
    {

        if (volume.profile.TryGet<ChromaticAberration>(out cr))
        {
            tcr = 0;
            cr.intensity.value = 0;
        }
        if (volume.profile.TryGet<FilmGrain>(out fg))
        {
            tfg = 0;
            fg.intensity.value = 0;
        }
        volumeObject.SetActive(false);
    }

    public void ActivateVolume()
    {
        if (!volumeObject.activeSelf)
        {
            Debug.Log("ATIVOU OBJETO");
            volumeObject.SetActive(true);
        }

        if(volume.profile.TryGet<ChromaticAberration>(out cr))
        {
            if (tcr != 0.1f)
            {
                tcr += 0.1f * Time.deltaTime;
            }
            cr.intensity.value = Mathf.Lerp(0F, 10F, tcr);
        }
        if(volume.profile.TryGet<FilmGrain>(out fg))
        {
            if(tfg != 1.0f)
            {
                tfg += 0.3f * Time.deltaTime;
            }
            fg.intensity.value = Mathf.Lerp(0F, 1f, tfg);
        }
    }

    public void SetObjectColors(string colorHex)
    {
        foreach (var sprite in GameObject.FindGameObjectsWithTag("Clue"))
        {
            ColorUtility.TryParseHtmlString(colorHex, out now);
            sprite.gameObject.GetComponent<SpriteRenderer>().color = now;
        }
    }
}
