using UnityEngine;
using System.Collections;

public class PickupSpawner : MonoBehaviour {
	public float waitTime = 2;
	public float repeatTime = 4;
	public float maxPickups = 100;

	public GameObject pickup;

	void Start () {
		for (int i = 0; i <= maxPickups * (3.0f/4.0f); i++)
		{
			Instantiate(pickup);
		}

		//InvokeRepeating("Spawn", waitTime, repeatTime);
	}

	/*void Spawn()
	{
		Instantiate(pickup);
	}*/
}
