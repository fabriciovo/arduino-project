using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private GameObject effect;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "spin"){
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
