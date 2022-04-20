using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool canPlay = true;
    private float timeRemaining = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlay)
        {
            Debug.Log(timeRemaining);
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Attack();
                
            }
        }
    }

    private void Attack()
    {
        Debug.Log("ENemy attack");
        canPlay = false;
    }
}
