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
    [SerializeField] public UIController UIController;
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
        if (playerTurn && !enemyController.dead)
        {
            playerController.canPlay = true;
            UIController.changeTurn("Player Turn");
        }
        else if(!playerTurn && !enemyController.dead)
        {
            enemyController.canPlay = true;
            UIController.changeTurn("Enemy Turn");

        }
        else
        {
            playerController.canPlay = false;
            UIController.changeTurn("Shop Turn");
        }
    }
    public void ResetEnemy()
    {
        enemyController.ResetEnemy();
    }

    public void PlayerDamage(int value)
    {
        playerController.Damage(value);
    }

    public void EnemyDamage(int value)
    {
        
        enemyController.Damage(value);
        if (enemyController.hp <= 0)
        {
           
            UIController.openShop();

        }
    }
}
