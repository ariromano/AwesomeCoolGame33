using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorCard : MonoBehaviour
{
	public float targetPosition; //where should the card be visually?
	public AwesomeRule rule; //the rule associated with the card
    // Start is called before the first frame update
	private Renderer myRenderer;
	//visuals
	public Color emissiveSelected = Color.green;
	public Color emissiveUnSelected = Color.black;

    void Start()
    {
		myRenderer = GetComponent<Renderer> ();
		if(rule){
			myRenderer.material.SetTexture("_MainTex", rule.image);
		} else {
			Debug.LogError("a conveyor card has been spawned but no rule assigned");
		}
    }

    // Update is called once per frame
    void Update()
    {
		//move card to targetPosition
		Vector3 newPosition = new Vector3(targetPosition, 0.0f, 0.0f);
		transform.localPosition = newPosition;
    }
	public void highlight(){
		Debug.Log("highlighting card: " + rule.name);
		/*
		Debug.Log("highlighting card: " + rule.name);
		String[] properties = myRenderer.material.GetPropertyNames(MaterialPropertyType.Vector);
		foreach(string s in properties){
			Debug.Log("property: " + s);
		}
		*/
		myRenderer.material.SetColor("_EmissionColor", emissiveSelected);
		myRenderer.material.EnableKeyword("_EMISSION");

	}
	public void unHighlight(){
		myRenderer.material.SetColor("_EmissionColor", emissiveUnSelected);
		myRenderer.material.EnableKeyword("_EMISSION");

	}
}
