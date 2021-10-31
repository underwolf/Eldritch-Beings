using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float speed = 40f;
    public GameObject aimObj,playerAimSprites,playerNormalSprites;
    public bool useAnimator, canMove = true;
    public Animator animator;
    public bool directionWasFacing;
    float horizontal = 0f;
    bool jump = false,crouch=false;

    [Header("CUTSCENE TOGGLE")]
    public bool isCutscene = false;
    [Header("HEALTH PLAYER STUFF")]
    public bool isAiming=false;


    private void Awake()
    {
        useAnimator = true;
        controller.movementSpeed = speed;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isCutscene)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                controller.CancelMovement();
                canMove = false;
                controller.canMove = false;
                controller.isAiming = true;
                aimObj.SetActive(true);
                playerAimSprites.SetActive(true);
                playerNormalSprites.SetActive(false);
                useAnimator = false;
                controller.useAnimator = false;
                isAiming = true;
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
                controller.useAnimator = true;
                isAiming = true;
            }
            Movement();
            if (!canMove)
            {
                controller.Move(0.0f, false, false);
                controller.CancelMovement();
                controller.canMove = false;
            }
        }

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
