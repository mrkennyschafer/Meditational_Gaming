using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour
{

	private Transform player;

	private Vector3 CamPos;
	private float offSetZ;
	private float offSetY;
	//private Vector3 lastTargetPos;
	private Vector3 currentVelocity;
	//private Vector3 lookAheadPos;




	// Use this for initialization
	void Awake () 
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;	
		ResetTargetPos ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		Vector3 aheadTargetPos = player.position + Vector3.forward*offSetZ;
		//Vector3 CurrentCamPos = player.position + CamPos + Vector3.forward*offSetY;
		Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, 0f);
		
		transform.position = newPos;
		
		//lastTargetPos = player.position;
		
		ResetTargetPos ();

	
	}

	void ResetTargetPos()
	{
		//lastTargetPos = player.position;
		offSetZ = (transform.position - player.position).z;
	}
	
}
