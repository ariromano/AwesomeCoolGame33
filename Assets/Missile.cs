using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // Start is called before the first frame update
	public float thrust = 3.0f;
	public float initTime = 2.0f;
	float startTime;
	private Rigidbody rb;
    void Start()
    {
		startTime = Time.time;
		rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime > initTime){
			Vector3 thrustVector = new Vector3(0,thrust,0);
			Vector3 thrustWorldVector = transform.TransformDirection(thrustVector);
			rb.AddForce(thrustWorldVector);
		}
    }
}
