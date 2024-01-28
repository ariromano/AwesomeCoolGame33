using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class hurtOnTouch : MonoBehaviour
{
    // Start is called before the first frame updat

    void Start()
    {
        Debug.Log("Hello World");
    }
    public float atkDmg;

    private void OnCollisionEnter(Collision touch){
       playerHealth health = GameObject.Find("player").GetComponent<playerHealth>(); 
       if(touch.gameObject.name==("player")){
           health.takeDamage(atkDmg);
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
