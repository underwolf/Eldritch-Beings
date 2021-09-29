using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float speed = 40f;
    public GameObject aimObj,playerAimSprites,playerNormalSprites;
    public bool useAnimator;
    public Animator animator;

    float horizontal = 0f;
    bool jump = false,crouch=false,canMove=true;


    private void Awake()
    {
        useAnimator = true;
        controller.movementSpeed = speed;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            canMove = false;
            controller.canMove = false;
            controller.isAiming = true;
            aimObj.SetActive(true);
            playerAimSprites.SetActive(true);
            playerNormalSprites.SetActive(false);
            useAnimator = false;

            FindObjectOfType<CharacterController2D>().useAnimator = false;


        }
        if (Input.GetButtonUp("Fire2"))
        {
            canMove = true;
            controller.canMove = true;
            controller.isAiming = false;
            aimObj.SetActive(false);
            playerAimSprites.SetActive(false);
            playerNormalSprites.SetActive(true);
            useAnimator = true;
            FindObjectOfType<CharacterController2D>().useAnimator = true;
        }
        Movement();

        
    }


    private void Movement()
    {
        if (canMove)
        {
            if (horizontal != 0)
            {
                controller.isMoving = true;
            }
            else
            {
                controller.isMoving = false;
            }
            controller.Move(horizontal * Time.fixedDeltaTime, crouch, jump);

            jump = false;
            horizontal = Input.GetAxisRaw("Horizontal") * speed;
            if (useAnimator)
            {
                animator.SetFloat("Speed", Mathf.Abs(horizontal));
            }

            if (Input.GetButtonDown("Jump"))
            {
               
                jump = true;
                
            }
            if (Input.GetButtonUp("Jump"))
            {
                controller.CancelJump();
            }

        }
    }

}
