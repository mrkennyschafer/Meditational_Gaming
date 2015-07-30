using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	// test change for git hub

	[SerializeField] private bool airControl = true; // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask whatIsGround; // A mask determining what is ground to the character
	[HideInInspector]public Animator Anim;
	[HideInInspector] public bool bFacingRight = true;
	
	
	public Rigidbody2D rb2D;
	public bool bRoll;
	private Transform groundCheck; // A position marking where to check if the player is grounded.
	private float groundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool bGrounded; // Whether or not the player is grounded.
	private bool bMagnetic; // Whether or not the player is grounded.
//	private Transform ceilingCheck; // A position marking where to check for ceilings
//	private float ceilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
	private float maxSpeed;
	private float defaultSpeed = 10f;
	private bool bJump;

	private BoxCollider2D PlayerBoxCollider;

	

	// Use this for initialization
	void Awake () 
	{
		PlayerBoxCollider = gameObject.GetComponent<BoxCollider2D>();
		groundCheck = transform.Find("GroundCheck");
		//ceilingCheck = transform.Find("CeilingCheck");
		Anim = GetComponent<Animator> ();
	

	}

	private void Update()
	{

		
		//if(!bJump)
			// Read the jump input in Update so button presses aren't missed.
		//	bJump = Input.GetButtonDown("Jump");


		//  only if we are not rolling should the player jump
			if (Input.GetButtonDown ("Jump")) 
				bJump = true;

			else
				bJump = false;


		DoRoll ();

		

	
	}

	
	// Update is called once per frame
	void FixedUpdate () 
	{

		bGrounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
		Anim.SetBool("Ground", bGrounded);

		float horizontal =  Input.GetAxisRaw("Horizontal");
		bool bCrouch = Input.GetKey(KeyCode.LeftControl);
      //  Anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
		
	    //int vertical = (int)Input.GetAxisRaw ("Vertical");
		Move (horizontal, bCrouch, bJump);

	

	
	}


		
	void DoRoll()
	{
			// If roll is pressed
		if (Input.GetButtonDown ("Fire2"))
		{
			bRoll = true; // set true
			FireWeapons.bCanShoot = false;
			PlayerBoxCollider.enabled = false;
		}

		// if roll is released 
		else if (Input.GetButtonUp ("Fire2"))
		{
			bRoll = false;	// set false
			FireWeapons.bCanShoot = true;
			PlayerBoxCollider.enabled = true;
			
			
		}


		//  Set Animator bool  to the value of bRoll;
		Anim.SetBool("bRoll", bRoll);

		// store the Animator Bool in a varible
		bool bRolling = Anim.GetBool ("bRoll");


		// if rolling animation is playing 
		if(bRolling)
			maxSpeed = 20f; // Increace speed
		else
			maxSpeed =defaultSpeed;// set speed to normial
			

			
	}


	void Move(float move, bool bCrouch, bool bJump)
	{


		//only control the player if grounded or airControl is turned on
		if (bGrounded || airControl)
		{
			// Reduce the speed if crouching by the crouchSpeed multiplier
			//move = (bCrouch ? move*bFacingRight : move);
			
			// The Speed animator parameter is set to the absolute value of the horizontal input.
			Anim.SetFloat("Speed", Mathf.Abs(move));
			
			// Move the character

			if (bGrounded || bRoll)
			GetComponent<Rigidbody2D>().velocity = new Vector2(move*maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
			
			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !bFacingRight)
				// ... flip the player.
				Flip();
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && bFacingRight)
				// ... flip the player.
				Flip();
			
		}
	
		// If the player should jump...

		if (bGrounded && bJump && Anim.GetBool("Ground"))
		{
			// Add a vertical force to the player.
			bGrounded = false;
			Anim.SetBool("Ground", false);

			if (!bRoll)
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 400f));

			else
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 700f));
				

		}

		// The Speed animator parameter is set to the absolute value of the horizontal input.
		Anim.SetFloat ("Speed", Mathf.Abs(move));
		
	}



	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		bFacingRight = !bFacingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


}
