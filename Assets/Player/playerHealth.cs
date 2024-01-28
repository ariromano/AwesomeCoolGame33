using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public float currentHealth = 1;

    public void takeDamage(float damageTaken){
		Debug.Log("ouch");
        currentHealth-=damageTaken;
        if(currentHealth<=0){
            playerDie();
        }
    }

    public void playerDie(){
        Destroy(gameObject);
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

}