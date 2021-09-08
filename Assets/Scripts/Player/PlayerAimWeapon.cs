using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;
    public GameObject aimObject;
    public GameObject firepoint;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos=UtilsClass.GetMouseWorldPosition();
        

        Vector3 aimDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x)*Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        Vector3 aimLocalScale = Vector3.one;
        Vector3 theScale = transform.localScale;
        if (aimObject.activeSelf) { 
            if (angle>90 || angle < -90)
            {
                aimLocalScale.y = -1f;
                aimLocalScale.x = -1f;
                theScale.x = -1;
                
                transform.localScale = theScale;
            }
            else
            {
                aimLocalScale.y = +1f;
                aimLocalScale.x = +1f;
                theScale.x = +1;
                
                transform.localScale = theScale;
            }
        }
        aimTransform.localScale = aimLocalScale;

    }
}
