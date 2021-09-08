using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BulletCounter : MonoBehaviour
{

    public TMP_Text textoBullets;
    void Update()
    {
        textoBullets.text =""+transform.childCount;
    }
}
