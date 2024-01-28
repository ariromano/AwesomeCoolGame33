using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawn", menuName = "Awesome Rules/Spawn", order = 1)]

public class SpawnRule : AwesomeRule
{
	public GameObject objectToSpawn;
	public float spawnAreaSize = 3.0f;
	public bool randomizeRotation = false;
	public float spawnHeight = 3.0f;


	public override void Trigger()
	{
		if(objectToSpawn){
			float randX = Random.Range(-spawnAreaSize, spawnAreaSize);
			float randY = Random.Range(-spawnAreaSize, spawnAreaSize);

			Vector3 spawnPos = new Vector3(randX,spawnHeight,randY);
			Quaternion rot = Quaternion.identity;
			if(randomizeRotation){ rot = Random.rotation ;}
			Instantiate(objectToSpawn, spawnPos, rot);

		}
	}
}
