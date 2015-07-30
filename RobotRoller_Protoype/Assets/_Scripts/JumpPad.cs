using UnityEngine;
using System.Collections;

public class JumpPad : MonoBehaviour 
{

	public float Xdir;
	public float Ydir;
	private Rigidbody2D PlayerRb2D; 
	private Vector2 currentVelocity;
	

	void Awake()
	{
		PlayerRb2D = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentVelocity = PlayerRb2D.velocity;
	
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{

			PlayerRb2D.AddForce(new Vector2(Xdir, Ydir) - currentVelocity);
			
		}
	}
}
