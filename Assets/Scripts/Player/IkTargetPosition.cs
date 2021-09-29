using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkTargetPosition : MonoBehaviour
{
    void Update()
    {
        Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseCursorPos;
    }
}
