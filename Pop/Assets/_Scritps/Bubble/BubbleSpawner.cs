using UnityEngine;
using System.Collections;

public class BubbleSpawner : MonoBehaviour 
{
	public GameObject[] bubble; // bubble game object Assing via inspector
	public Vector2 spawnPos; // vector use for the spawn pos

	private float bubbleStartWait =0.3f; //  Seconds waited beform the IEnumerator starts
	//private float bubbleWaveWait = 1f;
	private float bubbleSpawnWait = 1.5f;  //  time between each bubble spawn;


	// Use this for initialization
	void Start () 
	{
	

		StartCoroutine (SpawnBubbles ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		//SpawnBubbles ();
	}

	IEnumerator SpawnBubbles()
	{
		
		yield return new WaitForSeconds (bubbleStartWait);
		
		while (true) 
		{

		GameObject Bubble = bubble[Random.Range(0, bubble.Length)];
		Vector2 spawnLoc = new Vector2 (Random.Range (-spawnPos.x, spawnPos.x), spawnPos.y);
		Instantiate(Bubble, spawnLoc,gameObject.transform.rotation);
		yield return new WaitForSeconds(bubbleSpawnWait);
		//yield return new WaitForSeconds (bubbleWaveWait);
			

		}
	}
		

}
