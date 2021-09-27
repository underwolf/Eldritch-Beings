using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float speed = 40f;
    public GameObject aimObj;

    public Animator animator;

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
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
            if (Input.GetButtonDown("Jump"))
            {
               
                jump = true;
                
            }
            if (Input.GetButtonUp("Jump"))
            {
                controller.CancelJump();
            }

        }
        else
        {
            controller.Move(0, false, false);
        }

    }
}
