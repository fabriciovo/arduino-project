using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private GameObject player;
    private CharacterController controller;
    private Vector3 playerPos;
    private Vector3 velocity;
    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
        controller = GetComponent<CharacterController>();
    }
    void Start()
    {
        // Add + 1 to player's last known position so bullet appears to float above ground.
        playerPos = player.transform.position;
    }

    void Update(){

        Vector3 direction = playerPos - transform.position;
        direction.Normalize();
        velocity = direction * 3;

        controller.Move(velocity * Time.deltaTime);


    }

}
