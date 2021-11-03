using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public bool switchState;
    private Openable openableScript;

    private void Awake()
    {
        switchState = false;
        openableScript = GetComponent<Openable>();
    }
    private void Update()
    {
        switchState = openableScript.isOpen;

    }
}
