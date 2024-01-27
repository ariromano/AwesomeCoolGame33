using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Speed", menuName = "Awesome Rules/Speed", order = 1)]

public class SpeedRule : AwesomeRule
{

	public float setSpeed;

	public override void Trigger()
	{
		player_movement movement = GameObject.Find("player").GetComponent<player_movement>();
		movement.playerSpeed=setSpeed;

	}
}