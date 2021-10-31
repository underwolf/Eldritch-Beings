using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
    [SerializeField] private float m_hangTime = .2f;                            // Coyote Time
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;							// A position marking where to check for ceilings
	[SerializeField] private Collider2D m_CrouchDisableCollider;				// A collider that will be disabled when crouching

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	public bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
    private float hangCounter;
    public bool canMove;
    public bool useAnimator;
    public bool isAiming;
    public bool isMoving;
    public bool isCultist;
    public float movementSpeed=40f;


    //SLOPE VARIABLES
    public CapsuleCollider2D groundCollider;
    private Vector2 colliderSize;
    [SerializeField] private float slopeCheckDistance, slopeSideAngle;
    private float slopeDownAngle;
    private Vector2 slopeNormalPerp;
    private bool isOnSlope;
    private float slopeDownAngleOld;
    public PhysicsMaterial2D onSlopeMaterial, OfSlopeMaterial;


	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
	private bool m_wasCrouching = false;

    public Animator animator;

    private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

        useAnimator = true;
        canMove = true;

        //SLOPE CODE
        groundCollider = GetComponent<CapsuleCollider2D>();
        colliderSize = groundCollider.size;
        

        if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();
	}

    //SLOPE FUNCTION
    private void SlopeCheck()
    {
        Vector2 checkPos = transform.position - new Vector3(0.0f, colliderSize.y / 2);
        SlopeCheckVertical(checkPos);
        SlopeCheckHorizontal(checkPos);
    }
    private void SlopeCheckHorizontal(Vector2 checkPos)
    {
        RaycastHit2D slopeHitFront = Physics2D.Raycast(checkPos, transform.right, slopeCheckDistance, m_WhatIsGround);
        RaycastHit2D slopeHitBack = Physics2D.Raycast(checkPos, -transform.right, slopeCheckDistance, m_WhatIsGround);

        if (slopeHitFront)
        {
            isOnSlope = true;

            slopeSideAngle = Vector2.Angle(slopeHitFront.normal, Vector2.up);

        }
        else if (slopeHitBack)
        {
            isOnSlope = true;

            slopeSideAngle = Vector2.Angle(slopeHitBack.normal, Vector2.up);
        }
        else
        {
            slopeSideAngle = 0.0f;
            isOnSlope = false;
        }

    }
    private void SlopeCheckVertical(Vector2 checkPos)
    {

        RaycastHit2D hit = Physics2D.Raycast(checkPos, Vector2.down,slopeCheckDistance,m_WhatIsGround);
        if (hit)
        {
            slopeNormalPerp = Vector2.Perpendicular(hit.normal).normalized;
            slopeDownAngle = Vector2.Angle(hit.normal,Vector2.up);
            if (slopeDownAngle != slopeDownAngleOld)
            {
                isOnSlope = true;

            }
            slopeDownAngleOld = slopeDownAngle;


            Debug.DrawRay(hit.point, slopeNormalPerp, Color.red);
            Debug.DrawRay(hit.point, hit.normal,Color.green);
        }
        
    }

    private void FixedUpdate()
	{

		bool wasGrounded = m_Grounded;
		m_Grounded = false;

        if (useAnimator)
        {
            animator.SetBool("Grounded", false);
        }

        SlopeCheck();
        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;

                if (useAnimator)
                {
                    animator.SetBool("Grounded", true);
                }

                if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}

        
	}
    private void Update()
    {
        if (useAnimator && !isOnSlope)
        {
            animator.SetFloat("VerticalSpeed", m_Rigidbody2D.velocity.y);
        }
        if (isOnSlope && !isMoving)
        {
            groundCollider.sharedMaterial = onSlopeMaterial;
        }if(isOnSlope && isMoving)
        {
            groundCollider.sharedMaterial = OfSlopeMaterial;
        }

        

    }


    public void Dash(float dashDistance)
    {

        if (m_FacingRight)
            m_Rigidbody2D.AddForce(Vector2.right * dashDistance, ForceMode2D.Impulse);
        if (!m_FacingRight)
            m_Rigidbody2D.AddForce(Vector2.left * dashDistance, ForceMode2D.Impulse);

    }
    public void Move(float move, bool crouch, bool jump)
	{


		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{
			/// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            if (canMove)
            {
                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }

                // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }

		}

        if (m_Grounded)
        {
            hangCounter = m_hangTime;
            if (!isAiming)
            {
                canMove = true;
            }

        }
        else
        {
            hangCounter -= Time.deltaTime;
        }
		// If the player should jump...
		if (hangCounter>0 && jump)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
            if (useAnimator){
                animator.SetBool("Grounded", false);
            }
            //canMove = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}

	}


    public float GetVelocity()
    {
        return m_Rigidbody2D.velocity.x;
    }
	public void Flip()
	{
        m_FacingRight = !m_FacingRight;
        if (isCultist)
        {
            transform.Rotate(0f, 180f, 0f);
        }
        else
        {
            Vector3 theScale = transform.localScale;
            if (m_FacingRight)
            {
                theScale.x = 1;
            }
            else
            {
                theScale.x = -1;
            }

            transform.localScale = theScale;
        }


    }
    public void CancelMovement()
    {
        m_Rigidbody2D.velocity = new Vector2(0, m_Rigidbody2D.velocity.y);
    }

    public void Die()
    {
        animator.SetFloat("VerticalSpeed", 0);
        animator.SetBool("Grounded", true);

        animator.SetFloat("Speed", 0);
    }

    public void CancelJump()
    {
        if  (m_Rigidbody2D.velocity.y > 0)
        {
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, m_Rigidbody2D.velocity.y * .5f);
        }
    }

}
