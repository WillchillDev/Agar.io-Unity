using UnityEngine;
using System.Collections;

public class PickupSpawner : MonoBehaviour {
	public float spawnTime = 1.5f;
	public float maxPickups = 100;

	public GameObject pickup;

    void Start () {
		for (int i = 0; i <= maxPickups * (3.0f/4.0f); i++)
		{
			Instantiate(pickup);
		}

		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	void Spawn()
	{
		GameObject[] pickups;
		pickups = GameObject.FindGameObjectsWithTag("Pickup");
		if (pickups.Length < maxPickups)
		{
			Instantiate(pickup);
		}
		
	}
}
