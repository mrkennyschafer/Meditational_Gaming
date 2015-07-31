using UnityEngine;
using System.Collections;

public class PlayerTouchController : MonoBehaviour 
{

	[SerializeField] private LayerMask whatIsGround; // Distigushes what is ground in this case bubble  "bubble have the layer mask asigned to them vis inspector" 
	public Transform bubbleCheck; // transform use to detect if the player is touching the ground 
	public float bubbleCheckRadius = 0.2f; // the radius to check for
	
	private Rigidbody2D playerRb2d; // will hold reference to the players Rigidbody2D Component


	// Use this for initialization
	void Start () 
	{
	
	}

	void Awake()
	{
		// Gain reference to the rigidbody component of the player
		playerRb2d = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
		// get the transform location of the ColliderCheck game object "Is a child of the Player"
		bubbleCheck = transform.Find("BubbleCheck");
	}

	
	// Update is called once per frame
	void Update ()
	{

	
	
	}

	void FixedUpdate()
	{

		// Check to see if a bubble is overlaping the bubble check postion
		if (Physics2D.OverlapCircle (bubbleCheck.position, bubbleCheckRadius, whatIsGround))
		{
			playerRb2d.mass = 0; //  remove players mass so they wont push the bubble down instead the bubble floats them up
			Debug.Log("on Ground");
		}
		else 
			playerRb2d.mass = 1f; // reset mass back to normal;
			


	}
}
