using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Speed", menuName = "Awesome Rules/Speed", order = 1)]

public class SpeedRule : AwesomeRule
{

	public float setSpeed;

	public override void Trigger()
	{
		//player_movement movement = GameObject.Find("player").GetComponent<player_movement>();
		
		player_movement[] playersFound;
		playersFound = FindObjectsByType<player_movement>(FindObjectsSortMode.None);

		int pickedPlayer = Random.Range(0,playersFound.Length-1);
		//playertransform = playersFound[pickedPlayer].transform;

		if(playersFound[pickedPlayer]){
			playersFound[pickedPlayer].playerSpeed = setSpeed;
		}

	}
}