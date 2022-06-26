using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    [SerializeField] private string tag;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tag)
        {
            Destroy(other);
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
