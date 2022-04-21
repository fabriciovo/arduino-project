using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool canPlay = false;
    public int hp = 100;
    [SerializeField] private GameController gameController;
    private float timeRemaining = 10;

    // Update is called once per frame
    void Update()
    {
        if (canPlay)
        {
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
        Debug.Log("Enemy attack");
        canPlay = false;
        gameController.playerTurn = true;
        timeRemaining = 10.0f;
    }
    public void ResetEnemy()
    {
        canPlay = false;
        gameController.playerTurn = true;
        timeRemaining = 10.0f;
    }
    public void Damage(int value)
    {
        hp -= value;
    }
}
