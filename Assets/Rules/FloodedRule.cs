using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Flood", menuName = "Awesome Rules/Flood", order = 1)]

public class FloodedRule : AwesomeRule
{
    public GameObject the_flood;

	public override void Trigger()
	{
		Instantiate(the_flood);
	}
}