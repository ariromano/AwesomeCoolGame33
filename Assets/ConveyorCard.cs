using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorCard : MonoBehaviour
{
	public float targetPosition; //where should the card be visually?
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//move card to targetPosition
		Vector3 newPosition = new Vector3(targetPosition, transform.position.y, transform.position.z);
		transform.position = newPosition;
    }
}
