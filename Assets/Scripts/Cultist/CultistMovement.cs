using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultistMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float speed = 60f;
    public GameObject drawObject;
    public bool useAnimator;
    public Animator animator;
    public bool directionWasFacing;
    public float dashDistance;

    private bool isDashing;
    float horizontal = 0f;
    bool jump = false, crouch = false, canMove = true;


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
            drawObject.SetActive(true);
            Time.timeScale = 0.5f;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            Debug.Log("TRIED TO DASH");
            controller.Dash(dashDistance);
            StartCoroutine(dashCount());
        }
        Movement();
    }

    public void DisableDrawObject()
    {
        drawObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    IEnumerator dashCount()
    {
        isDashing = true;
        Debug.Log("COMEÇOU A COROTINA" + Time.deltaTime);
        yield return new WaitForSeconds( .5f);
        isDashing = false;
        Debug.Log("PAROU A COROTINA" + Time.deltaTime);

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
