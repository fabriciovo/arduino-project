using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{

    [SerializeField]private TMP_Text turn;
    [SerializeField] private TMP_Text score;
    //player
    [SerializeField] private TMP_Text playerHp;
    [SerializeField] private TMP_Text gold;
    [SerializeField] private TMP_Text power;
    [SerializeField] private List<GameObject> items;


    //Enemy
    [SerializeField] private TMP_Text enemyHp;
    [SerializeField] private TMP_Text enemyLevel;

    //Shop
    [SerializeField] private GameObject shopPanel;
    // Start is called before the first frame update

    public bool shop = false;

    private void Awake()
    {
        shopPanel.SetActive(false);
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Return)) ) { 
            CreateNewEnemy();
        } 
    }

    public void changeTurn(string value)
    {
        turn.text = value;
    }
    public void changeScore(string value)
    {
        score.text = "Score: " + value;
    }
    public void changePlayerHp(string value)
    {
        playerHp.text = "HP: " + value;
    }
    public void changeGold(string value)
    {
        gold.text = "Gold: " + value;
    }
    public void changePower(string value)
    {
        power.text = "Power: " + value;
    }
    public void changeEnemyHp(string value)
    {
        enemyHp.text = "HP: " + value;
    }
    public void changeEnemyLevel(string value)
    {
        enemyLevel.text = "Level: " + value;
    }
    public void drawItems(string value)
    {
       
    }

    public void openShop()
    {
        shop = true;
        shopPanel.SetActive(true);
        changeTurn("Shop Time");
    }


    public void CreateNewEnemy()
    {
        shop = false;
        shopPanel.SetActive(false);
        GameObject.Find("Enemy").GetComponent<EnemyController>().newEnemy();

    }
}
