using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    // Start is called before the first frame update
    public AwesomeRule[] AvailableRules;
    public GameObject CardPreview;
	public ConveyorCard[] cards;
	public int currentCardCount;
	//rules
	public int maxCards = 10;
	public float cardSpawnCadence = 5.0f;
	//status
	private float lastCardSpawnTime;
	int currentSpawnSlot = 0;
	//visuals
	public float cardDistance = 0.5f;
	//player 2 controls
	public KeyCode leftKey = KeyCode.LeftArrow;
	public KeyCode rightKey = KeyCode.RightArrow;
	public KeyCode selectKey = KeyCode.UpArrow;
	//control status
	public int currentlySelectedIndex = 0;

	void Start(){
		cards = new ConveyorCard[maxCards];
		lastCardSpawnTime = Time.time;
	}

	void FixedUpdate(){
		if(lastCardSpawnTime < Time.time - cardSpawnCadence){
			//SpawnCard();
		}

	}

	void Update(){
		//input
		if(currentCardCount>0){
			if(Input.GetKeyDown(leftKey)){
				SelectLeftCard();
			}

			if(Input.GetKeyDown(rightKey)){
				SelectRightCard();
			}

			if(Input.GetKeyDown(selectKey)){
				PlayCard();
			}
			//debug

		
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			SpawnCard();
		}
	}
	void SpawnCard(){
		lastCardSpawnTime = Time.time;
		if(currentSpawnSlot < maxCards - 1){
			cards[currentSpawnSlot] = Instantiate(CardPreview, transform).GetComponent<ConveyorCard>();
			Random.InitState((int)(Time.time * 10.0f));
			//pick random rule for the new card
			int pickedRule = Random.Range(0, AvailableRules.Length);
			//Debug.Log("spawning new card: " + AvailableRules[pickedRule].ruleName + " (rule #" + pickedRule.ToString() + ")");
			cards[currentSpawnSlot].rule = AvailableRules[pickedRule];
			currentSpawnSlot += 1;
			currentCardCount += 1;
		} else {
			//Debug.Log("conveyor is full");
		}
		RepositionCards();
	}
	void RepositionCards(){
		int i = 0;
		while(i < maxCards - 1){
			if(cards[i]){
				cards[i].targetPosition = i * cardDistance;
			}
			i++;
		}
	}

	void SelectLeftCard(){
		if(currentCardCount > 0){
			if(cards[currentlySelectedIndex]){
				cards[currentlySelectedIndex].unHighlight();
			}
			if(currentlySelectedIndex <= 0){
				//wrap around
				currentlySelectedIndex = currentCardCount - 1;
			} else {
				currentlySelectedIndex -= 1;
			}
			cards[currentlySelectedIndex].highlight();
		}
	}

	void SelectRightCard(){
		cards[currentlySelectedIndex].unHighlight();
		if(currentlySelectedIndex >= currentCardCount - 1){
			//wrap around
			currentlySelectedIndex = 0;
		} else {
			currentlySelectedIndex += 1;
		}
		cards[currentlySelectedIndex].highlight();
	}

	void PlayCard(){
		cards[currentlySelectedIndex].Play();
		//move all cards after this card down one slot
		int i = currentlySelectedIndex;
		while(i < maxCards - 2){
			cards[i] = cards[i+1];
			i++;
		}
		currentCardCount -=1;
		currentSpawnSlot -=1;
		RepositionCards();
		SelectLeftCard(); //after selecting a card the selection moves to the card to the left
	}

}
