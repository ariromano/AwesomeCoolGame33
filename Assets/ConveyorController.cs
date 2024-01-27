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
		lastCardSpawnTime = Time.time;
		if(currentSlot < maxCards - 1){
			currentCards[currentSlot] = Instantiate(CardPreview, transform).GetComponent<ConveyorCard>();
			Random.InitState((int)(Time.time * 10.0f));
			//pick random rule for the new card
			int pickedRule = Random.Range(0, AvailableRules.Length);
			Debug.Log("spawning new card: " + AvailableRules[pickedRule].ruleName + " (rule #" + pickedRule.ToString() + ")");
			currentCards[currentSlot].rule = AvailableRules[pickedRule];
			currentSlot +=1;
		} else {
			Debug.Log("conveyor is full");
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
