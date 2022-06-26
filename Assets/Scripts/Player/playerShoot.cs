using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject effect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enviroment")
        {
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
