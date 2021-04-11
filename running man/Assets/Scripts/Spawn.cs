using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
	public Transform[] spawnPoints;
	public GameObject[] monsters;
	int randomSpawnPoint, randomMonster;
	public static bool spawnAllowed;

	// Use this for initialization
	void Start()
	{
		spawnAllowed = true;
		InvokeRepeating("SpawnAMonster", 0f, 1f);
	}

	void SpawnAMonster()
	{
		if (spawnAllowed)
		{
			randomSpawnPoint = Random.Range(0, spawnPoints.Length);
			randomMonster = Random.Range(0, monsters.Length);
			Instantiate(monsters[randomMonster], spawnPoints[randomSpawnPoint].position,
				Quaternion.identity);

			if (randomMonster > 4)
			{
				randomMonster = 0;
			}
			else
			{
				randomMonster++;
			}

			if (randomSpawnPoint > 4)
			{
				randomSpawnPoint = 0;
			}
			else
			{
				randomSpawnPoint++;
			}
		}
	}
}
