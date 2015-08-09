using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public float spawnTime = 1.5f;
	public float maxEnemies = 20;

	public GameObject enemy;

	void Start()
	{
		for (int i = 0; i <= maxEnemies * (3.0f / 4.0f); i++)
		{
			Instantiate(enemy);
		}

		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}

	void Spawn()
	{
		GameObject[] enemies;
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		if (enemies.Length < maxEnemies)
		{
			Instantiate(enemy);
		}

	}
}
