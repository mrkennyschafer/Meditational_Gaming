using UnityEngine;
using System.Collections;

public class RicochetPlayer : MonoBehaviour
{

	private PlayerController Rpc;
	private Rigidbody2D PlayerRb2d;



	void Awake()
	{
		Rpc = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		PlayerRb2d = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Rpc.bRoll)
			gameObject.GetComponent<CircleCollider2D> ().enabled = true;
		else 
			gameObject.GetComponent<CircleCollider2D> ().enabled = false;
			
				
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "RicochetSurface")
			Ricochet ();
	}

	void Ricochet()
	{
		PlayerRb2d.AddForce (new Vector2(-PlayerRb2d.velocity.x *300, -PlayerRb2d.velocity.y * 300));

	}
}
