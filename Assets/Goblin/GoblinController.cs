using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinCrontroller : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 4.0f;
    private float jumpHeight = 2.0f;
    public float gravityValue = -9.81f;

     Transform playertransform;

    private void Start()
    {
		player_movement[] playersFound;
		playersFound = FindObjectsByType<player_movement>(FindObjectsSortMode.None);

		int pickedPlayer = Random.Range(0,playersFound.Length-1);
		playertransform = playersFound[pickedPlayer].transform;


        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        if(playertransform){
        Vector3 move = Vector3.Normalize(playertransform.position-transform.position);
        controller.Move(move * Time.deltaTime * playerSpeed);

        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }


        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }}


        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}

