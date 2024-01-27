using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Grav", menuName = "Awesome Rules/Grav", order = 1)]

public class GravRule : AwesomeRule
{

	public float setGravity;

	public override void Trigger()
	{
		player_movement movement = GameObject.Find("player").GetComponent<player_movement>();
		movement.gravityValue=setGravity;

	}
}