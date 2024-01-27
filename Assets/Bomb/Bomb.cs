using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	public float timer = 4.0f;
	float spawnTime;
    void Start()
    {
        spawnTime = Time.time;
    }

    void FixedUpdate()
    {
		if(Time.time > spawnTime + timer){
			Explode();
		}
    }
	void Explode(){
		Debug.Log("boom!");
		Destroy(gameObject, 1.0f);
	}
}
