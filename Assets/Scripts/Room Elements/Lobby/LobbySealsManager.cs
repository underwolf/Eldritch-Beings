using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbySealsManager : MonoBehaviour
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
            wineCellarSeal.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);

        if (PlayerPrefs.GetInt("WineCellarSeal") == 1)
            courtyardSeal.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1f, 1f);

        if (PlayerPrefs.GetInt("LibrarySeal") == 1
            && PlayerPrefs.GetInt("AtticSeal") == 1
            && PlayerPrefs.GetInt("CourtyardSeal") == 1
            && PlayerPrefs.GetInt("WineCellarSeal") == 1)
                secretDoor.SetActive(true);
    }
}
