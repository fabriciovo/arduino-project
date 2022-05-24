using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private bool grounded = false;
    // Update is called once per frame
    void Update()
    {

        if (player) { 
            // Rotate the camera every frame so it keeps looking at the target
            transform.LookAt(player.transform);

            // Same as above, but setting the worldUp parameter to Vector3.left in this example turns the camera on its side
            transform.LookAt(player.transform, Vector3.left);


            GetComponent<NavMeshAgent>().SetDestination(player.transform.position);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }
}
