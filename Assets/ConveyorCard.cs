using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorCard : MonoBehaviour
{
	public float targetPosition; //where should the card be visually?
	public AwesomeRule rule; //the rule associated with the card
    // Start is called before the first frame update
	private Renderer renderer;
    void Start()
    {
		renderer = GetComponent<Renderer> ();
		if(rule){
			renderer.material.SetTexture("_MainTex", rule.image);
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
}
