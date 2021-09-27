using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoorManager : MonoBehaviour
{
    public GameObject switchL, switchR;
    public GameObject secretDoor;

    private SwitchScript switchScriptL, switchScriptR;

    private void Awake()
    {
        switchScriptL = switchL.GetComponent<SwitchScript>();
        switchScriptR = switchR.GetComponent<SwitchScript>();
    }
    private void Update()
    {
        if(switchScriptL.switchState && switchScriptR.switchState)
        {
            secretDoor.gameObject.SetActive(true);
        }
        else
        {
            secretDoor.gameObject.SetActive(false);
        }
    }
}
