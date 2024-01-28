using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public float currentHealth = 1;
	public float maxHealth = 10;

	public HealthBarController hbc;


    public void takeDamage(float damageTaken){
		Debug.Log("ouch");
        currentHealth-=damageTaken;
        if(currentHealth<=0){
            playerDie();
        }
		hbc.barFill = currentHealth/maxHealth;
    }

    public void playerDie(){
        Destroy(gameObject);
    }

    void Start()
    {
		currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
		hbc.barFill = currentHealth/maxHealth;
    }

}