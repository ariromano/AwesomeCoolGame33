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
	public int maxCards = 10;
	public float cardSpawnCadence = 5.0f;
	//status
	private float lastCardSpawnTime;
	int currentSlot = 0;
	//visuals
	public float cardDistance = 0.5f;

	void Start(){
		currentCards = new ConveyorCard[maxCards];
		lastCardSpawnTime = Time.time;
	}

	void FixedUpdate(){
		if(lastCardSpawnTime < Time.time - cardSpawnCadence){
			SpawnCard();
		}
	}
	void SpawnCard(){
		Debug.Log("spawning new card");
		lastCardSpawnTime = Time.time;
		if(currentSlot < maxCards - 1){
			currentCards[currentSlot] = Instantiate(CardPreview, transform).GetComponent<ConveyorCard>();
			currentSlot +=1;
		} else {
			Debug.Log("game over");
		}
		repositionCards();
	}
	void repositionCards(){
		int i = 0;
		while(i < maxCards-1){
			if(currentCards[i]){
				currentCards[i].targetPosition = i * cardDistance;
			}
			i++;
		}
	}
}
