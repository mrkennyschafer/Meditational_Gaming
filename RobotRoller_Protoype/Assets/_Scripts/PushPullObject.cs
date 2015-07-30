using UnityEngine;
using System.Collections;

public class PushPullObject : MonoBehaviour 
{
	[HideInInspector] public bool bGrabed;
	private Rigidbody2D PlayerRb2d;

	
	// Use this for initialization
	void Start () 
	{
	
	}

	void Awake()
	{
		PlayerRb2d = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
	}
	

	void Update()
	{


	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "PushObject")
		{
			if (Input.GetKeyDown(KeyCode.LeftShift))
				bGrabed = true;
			else if (Input.GetKeyUp(KeyCode.LeftShift))
				bGrabed = false;
				


			if (bGrabed)
			{
				other.GetComponent<Rigidbody2D>().velocity = PlayerRb2d.velocity;
				other.GetComponent<Rigidbody2D>().isKinematic = false;
			}
			else 
			{
				other.GetComponent<Rigidbody2D>().isKinematic = true;
			}

		}

	}






}
