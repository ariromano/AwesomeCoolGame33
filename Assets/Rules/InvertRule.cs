using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Invert", menuName = "Awesome Rules/Invert", order = 1)]

public class InvertRule : AwesomeRule
{

	public override void Trigger()
	{
		
		player_movement[] playersFound;
		playersFound = FindObjectsByType<player_movement>(FindObjectsSortMode.None);

		int pickedPlayer = Random.Range(0,playersFound.Length-1);

		if(playersFound[pickedPlayer]){
			playersFound[pickedPlayer].isInverted = !playersFound[pickedPlayer].isInverted;
		}

	}
}