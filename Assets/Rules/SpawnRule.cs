using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawn", menuName = "Awesome Rules/Spawn", order = 1)]

public class SpawnRule : AwesomeRule
{
	public GameObject objectToSpawn;

	public override void Trigger()
	{
		Instantiate(objectToSpawn);
	}
}
