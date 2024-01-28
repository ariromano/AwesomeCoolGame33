using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class hurtOnTouch : MonoBehaviour
{
    // Start is called before the first frame updat

    void Start()
    {
       //Debug.Log("Hello World");
    }
    public float atkDmg;

    private void OnTriggerStay(Collider other){
		Debug.Log("damage thing detected");

       if(other.gameObject.GetComponent<playerHealth>()){
           other.gameObject.GetComponent<playerHealth>().takeDamage(atkDmg);
         // Debug.Log("Touch player :)");
         // Destroy(touch.gameObject);
        //
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
