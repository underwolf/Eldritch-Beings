using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourtyardSealManager : MonoBehaviour
{
    public GameObject azathotSeal;
    public GameObject[] courtyardEntities;
    public GameObject exitDoorSeal;

    private void Awake()
    {
        courtyardEntities = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void Update()
    {
        if (azathotSeal.GetComponent<SwitchScript>().switchState)
        {
            PlayerPrefs.SetInt("CourtyardSeal", 1);


            GetComponent<UIFXManager>().scaryUIFXColor.a = 1f;
            GetComponent<UIFXManager>().scaryUIFX.color = GetComponent<UIFXManager>().scaryUIFXColor;

            exitDoorSeal.SetActive(false);
            foreach (GameObject entity in courtyardEntities)
            {
                entity.transform.GetChild(0).GetComponent<CourtyardEntity>().speed = 1300f;
                entity.transform.GetChild(0).GetComponent<CourtyardEntity>().activateDistance = 1000f;
                entity.transform.GetChild(0).GetComponent<CourtyardEntity>().jumpNodeHeightRequirement = 0.3f;

            }
            azathotSeal.gameObject.SetActive(false);

        }
    }
}
