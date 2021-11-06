using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbySealManagerCultist : MonoBehaviour
{
    public GameObject librarySeal, atticSeal, wineCellarSeal, courtyardSeal;
    public GameObject secretDoor;


    private void Start()
    {
        if (PlayerPrefs.GetInt("LibrarySeal") == 1)
            librarySeal.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);

        if (PlayerPrefs.GetInt("AtticSeal") == 1)
            atticSeal.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f, 1f);

        if (PlayerPrefs.GetInt("CourtyardSeal") == 1)
            courtyardSeal.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1f, 1f);

        if (PlayerPrefs.GetInt("WineCellarSeal") == 1)
            wineCellarSeal.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);



        if (PlayerPrefs.GetInt("LibrarySeal") == 0)
            librarySeal.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);

        if (PlayerPrefs.GetInt("AtticSeal") == 0)
            atticSeal.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);

        if (PlayerPrefs.GetInt("CourtyardSeal") == 0)
            courtyardSeal.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);

        if (PlayerPrefs.GetInt("WineCellarSeal") == 0)
            wineCellarSeal.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);

        if (PlayerPrefs.GetInt("LibrarySeal") == 0
            && PlayerPrefs.GetInt("AtticSeal") == 0
            && PlayerPrefs.GetInt("CourtyardSeal") == 0
            && PlayerPrefs.GetInt("WineCellarSeal") == 0)
            secretDoor.SetActive(true);
    }
}
