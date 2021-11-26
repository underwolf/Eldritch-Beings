using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class OutsideChangeCamera : MonoBehaviour
{

    public CinemachineVirtualCamera cam1, camZoom;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        cam1.Priority = 0;
        camZoom.Priority = 1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cam1.Priority = 1;
        camZoom.Priority = 0;
    }
}
