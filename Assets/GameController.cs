using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool playerTurn = true;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject ui;


    [SerializeField] private PlayerController playerController;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private UIController UIController;
    void Awake()
    {  
        //player = PlayerManager.instance.Player;
        //enemy = EnemyManager.instance.Enemy;
        //ui = UIManager.instance.Ui;


        //playerController = player.GetComponent<PlayerController>();
        //enemyController = enemy.GetComponent<EnemyController>();
        //UIController = ui.GetComponent<UIController>();
}

    // Update is called once per frame
    void Update()
    {
        if (playerTurn)
        {
            playerController.canPlay = true;
            UIController.changeText("Player Turn");
        }
        else
        {
            enemyController.canPlay = true;
            UIController.changeText("Enemy Turn");

        }
    }
    public void ResetEnemy()
    {
        enemyController.ResetEnemy();
    }

    void PlayerDamage(int value)
    {
        playerController.Damage(value);
    }

    void EnemyDamage(int value)
    {
        enemyController.Damage(value);
    }
}
