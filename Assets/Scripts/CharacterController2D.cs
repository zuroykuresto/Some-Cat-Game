using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force player jumps.
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;			// Amount of maxSpeed to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// smooth out the movement
	[SerializeField] private bool m_AirControl = false;							
	[SerializeField] private LayerMask m_WhatIsGround;							// what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;							// position marking where to check for ceilings
	[SerializeField] private Collider2D m_CrouchDisableCollider;				// collider  will be disabled when crouching

	const float k_GroundedRadius = .2f; // Radius of the overlap circle 
	public bool m_Grounded;            // when grounded
	const float k_CeilingRadius = .2f; // Radius of  circle if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // which way the player is currently facing.
	private Vector3 velocity = Vector3.zero;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}


	private void FixedUpdate()
	{
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
				m_Grounded = true;
      
		}
	}


	public void Move(float move, bool crouch, bool jump)
	{
		// If crouching
		if (!crouch)
		{
			// If  ceiling preventing  standing up
			if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
			{
				crouch = true;
			}
		}

		if (m_Grounded || m_AirControl)
		{

			// If crouching
			if (crouch)
			{
				// Reduce the speed 
				move *= m_CrouchSpeed;

				// Disable colliders when crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
			} else
			{
				// Enable the collider when not crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;
			}

			// Move the character 
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing 
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);

			// facing left
			if (move < 0 && !m_FacingRight)
			{	
				Flip();
			}
			// facing right
			else if (move > 0 && m_FacingRight)
			{
				Flip();
			}
		}
		// If jump
		if (m_Grounded && jump)
		{
			// Add a vertical force
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));

        }
	}


	private void Flip()
	{
		// Switch the way the player
		m_FacingRight = !m_FacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
