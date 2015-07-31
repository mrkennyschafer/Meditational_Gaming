using UnityEngine;
using System.Collections;

// Author: Nathan Pussehl
// Date:
//Purpose: Use to control the floating of the bubble

public class Floater : MonoBehaviour 
{
	private Rigidbody2D bubbleRb2D;
	public float speed;

	// Use this for initialization
	void Start () 
	{

	
	}

	void Awake()
	{
		bubbleRb2D = GameObject.FindGameObjectWithTag ("Bubble").GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		bubbleRb2D.AddForce(new Vector2(Random.Range(-10,10), 1f) * speed);
	}
}
