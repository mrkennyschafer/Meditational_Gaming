using UnityEngine;
using System.Collections;

public class FireWeapons : MonoBehaviour 
{
	public static bool bCanShoot = true;
	public float FireRate; //  Time interval between check shot
	public float ShotRange;  //  Distance the shot goes

	private PlayerController playerController;

	private float Timer;
	private GameObject ShotSpawnPos; //  Pos of gameobject use as the spawn LOC of the projectile
	private LayerMask ShootableMask; //  layer mask use to determin whats shootabale
	private LineRenderer ShotLine; //  Line the represents the Proj path
	//private Ray ShotRay;
	//private RaycastHit ShotHit;
	private  Ray2D ShotRay; //  ray use to set proj path
	private RaycastHit2D ShotHit; //  ray hit use to determin if soanything shootable what hit
	private float EffectsDisplayTime = 0.2f; // amout of time till the weapon effect disapate 


	private Vector2 shootDirection; //  Direction the proj should go

	private Vector2 MousePos; //  Pos of the mouse cursor

	


	// Use this for initialization
	void Start () 
	{
	
	}

	void Awake()
	{
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		ShotSpawnPos = GameObject.FindGameObjectWithTag("ShotSpawn");
		ShootableMask = LayerMask.GetMask ("Shootable"); // get a reference to the shootable mask
		ShotLine = ShotSpawnPos.GetComponent<LineRenderer> ();   // get reference to the line AKA bullet

		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Timer += Time.deltaTime;

		//  set the shotdirection at the pos of the mouse cursor



			


		//MousePos = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Input.GetButton("Fire1") && Timer >= FireRate && Time.timeScale != 0)
		{
			ShotWeapon();
		}

		if (Timer >= FireRate * EffectsDisplayTime) 
		{
			DisableGunEffects ();
		}
		

	
	}



	void ShotWeapon()
	{

		if (bCanShoot != true)
			return;

		Timer = 0f;
		ShotLine.enabled = true; // turn on Line that represent bullet
		ShotLine.SetPosition (0, ShotSpawnPos.transform.position);//   start the buttle of the pos on the gun
		ShotRay.origin = ShotSpawnPos.transform.position;

		MousePos = Input.mousePosition;
		shootDirection = Camera.main.WorldToScreenPoint(ShotSpawnPos.transform.position);
		MousePos -= shootDirection;

		ShotRay.direction = MousePos;
			


		if (Physics2D.Raycast(ShotRay.origin, ShotRay.direction, ShotRange, ShootableMask))  
		{

			ShotLine.SetPosition (1, ShotHit.point);
			
		}
		else //  shot hit nothing shootable
		{
			//  line/bullet hit nothing 
			ShotLine.SetPosition (0, ShotRay.origin + ShotRay.direction * ShotRange);
		
		}


	}



	void DisableGunEffects()
	{
		ShotLine.enabled = false;
	}
}
