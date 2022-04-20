using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool playerTurn = true;
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

        if (enemyController.canPlay) {
            playerTurn = false;
            UIController.changeText("Enemy Turn");
        }
        if (playerController.canPlay)
        {
            playerTurn = true;
            UIController.changeText("Player Turn");
        }

        if (!playerController.canPlay && enemyController.canPlay)
        {
            enemyController.canPlay = true;

        }
        if (!enemyController.canPlay && playerController.canPlay)
        {
            playerController.canPlay = true;

        }
    }
}
