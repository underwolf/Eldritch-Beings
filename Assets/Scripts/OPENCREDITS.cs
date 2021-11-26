using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPENCREDITS : MonoBehaviour
{
    public GameObject CreditsObject, MenuObject;


    private void Start()
    {
        CreditsObject.SetActive(false);
        MenuObject.SetActive(true);
    }
    public void OpenCredits()
    {
        CreditsObject.SetActive(true);
        MenuObject.SetActive(false);
    }
    public void CloseCredits()
    {
        MenuObject.SetActive(true);
        CreditsObject.SetActive(false);
    }
}
