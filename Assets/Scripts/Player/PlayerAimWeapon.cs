using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PlayerAimWeapon : MonoBehaviour
{
    public Transform aimTransform;
    public GameObject aimObject;
    public GameObject firepoint;
    public GameObject IK_TARGET;
    public Animator animator;

    public Transform tragetTransform;
    public bool firstTimeEnter = false;
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos=UtilsClass.GetMouseWorldPosition();
        Vector3 aimDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x)*Mathf.Rad2Deg;
        Vector3 aimLocalScale = Vector3.one;
        Vector3 theScale = transform.localScale;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        firepoint.transform.eulerAngles = new Vector3(0, 0, angle);
        if (aimObject.activeSelf) { 
            if (angle>90 || angle < -90)
            {
                aimLocalScale.y = -1f;
                aimLocalScale.x = -1f;
                theScale.x = -1;
                // Debug.Log("Esquerda");
                FindObjectOfType<CharacterController2D>().m_FacingRight = false;
            }
            else
            {
                aimLocalScale.y = +1f;
                aimLocalScale.x = +1f;
                theScale.x = +1;
                FindObjectOfType<CharacterController2D>().m_FacingRight = true;
                //Debug.Log("Direita");
            }
            transform.localScale = theScale;
        }
        aimTransform.localScale = aimLocalScale;
        firepoint.transform.localScale = aimLocalScale;

    }

}
