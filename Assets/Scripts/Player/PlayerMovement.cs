using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float speed = 40f;
    public GameObject aimObj;

    float horizontal = 0f;
    bool jump = false,crouch=false,canMove=true;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            canMove = false;
            controller.canMove = false;
            aimObj.SetActive(true);
            
        }
        if (Input.GetButtonUp("Fire2"))
        {
            canMove = true;
            controller.canMove = true;
            aimObj.SetActive(false);
        }
        Movement();

        
    }


    private void Movement()
    {
        if (canMove)
        {
            
            controller.Move(horizontal * Time.fixedDeltaTime, crouch, jump);
            jump = false;
            horizontal = Input.GetAxisRaw("Horizontal") * speed;

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
            if (Input.GetButtonUp("Jump"))
            {
                controller.CancelJump();
            }

            if (Input.GetButtonDown("Crouch"))
            {
                transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z / 2);
                crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z * 2);
                crouch = false;
            }
        }
        else
        {
            controller.Move(0, false, false);
        }

    }
}
