using UnityEngine;
using System.Collections;

public class PickupSpawner : MonoBehaviour {
	public float spawnTime = 1.5f;
	public float maxPickups = 100;

	public GameObject pickup;
	public GameObject[] pickups;
    void Start () {
		for (int i = 0; i <= maxPickups * (3.0f/4.0f); i++)
		{
			Instantiate(pickup);
		}

		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	void Spawn()
	{
		pickups = GameObject.FindGameObjectsWithTag("Pickup");
		print("Number of pickups currently: " + pickups.Length.ToString());
		if (pickups.Length < maxPickups)
		{
			Instantiate(pickup);
			print("Spawned a pickup!");
		} else
		{
			print("Reached the max number of pickups!");
		}
		
	}
}
