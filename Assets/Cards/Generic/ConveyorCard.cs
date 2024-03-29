using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConveyorCard : MonoBehaviour
{
	public float targetPosition; //where should the card be visually?
	public AwesomeRule rule; //the rule associated with the card
    // Start is called before the first frame update
	public Renderer myRenderer;
	Animator animator;

	//visuals
	public Color emissiveSelected = Color.green;
	public Color emissiveUnSelected = Color.black;
	public float moveSpeed = 0.5f;
	public float spawnPosition = 8.0f;
	public float destructionTime = 1.0f;
	//text
	public TextMeshProUGUI text;

    void Start()
    {
		//myRenderer = GetComponent<Renderer> ();
		if(rule){
			myRenderer.material.SetTexture("_MainTex", rule.image);
		} else {
			Debug.LogError("a conveyor card has been spawned but no rule assigned");
		}
		Vector3 newPosition = new Vector3(spawnPosition, 0.0f, 0.0f);
		transform.localPosition = newPosition;
		animator = GetComponent<Animator>();
		//hide the text. we can only see if when the card is selected.
		text.gameObject.SetActive(false);
		//set the text to the name of the rule the card is about
		text.text = rule.ruleName;
    }

    // Update is called once per frame
    void Update()
    {
		float currentPosition = transform.localPosition.x;
		//move card to targetPosition
		float intermediatePosition = Mathf.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
		Vector3 newPosition = new Vector3(intermediatePosition, 0.0f, 0.0f);
		transform.localPosition = newPosition;
    }
	public void highlight(){

		myRenderer.material.SetColor("_EmissionColor", emissiveSelected);
		myRenderer.material.EnableKeyword("_EMISSION");
		animator.SetBool("isSelected", true);
		text.gameObject.SetActive(true);
	}
	public void unHighlight(){
		myRenderer.material.SetColor("_EmissionColor", emissiveUnSelected);
		myRenderer.material.EnableKeyword("_EMISSION");
		animator.SetBool("isSelected", false);
		text.gameObject.SetActive(false);

	}
	public void Play(){
		//play this card
		rule.Trigger();
		animator.SetBool("isPlayed", true);
		myRenderer.material.SetColor("_EmissionColor", emissiveUnSelected);
		myRenderer.material.EnableKeyword("_EMISSION");
		targetPosition = 8.0f;
		Destroy(gameObject, destructionTime);
	}
/*
	void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
		Vector3 visualizationVector = new Vector3(stopPosition, transform.position.y, transform.position.z);
        Gizmos.DrawSphere(transform.position, 1);
    }
	*/
}
