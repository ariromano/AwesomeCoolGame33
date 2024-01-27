using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    // Start is called before the first frame update
    public AwesomeRule[] AvailableRules;
    public GameObject CardPreview;
	public ConveyorCard[] currentCards;
	//rules
	public int maxCards;
	public float cardSpawnCadence = 5.0f;


	void Start(){
		currentCards = new ConveyorCard[maxCards];
	}
}
