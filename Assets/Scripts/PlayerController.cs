using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool canPlay = true;
    public bool endTurn = false;
    public int score = 0;
    private int hp = 10;
    private int gold = 0;
    private bool pressed = false;
    private int power = 100;
    private List<string> msgs = new List<string>();
    [SerializeField] private GameController gameController;
    private Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlay && !gameController.UIController.shop)
        {
            animator.Play("idle_turn");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                gameController.playerTurn = false;
                canPlay = false;
            }
        }
        else
        {
            
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    Attack();

            //}
        }
        gameController.UIController.changeScore(score.ToString());
        gameController.UIController.changePlayerHp(hp.ToString());
        gameController.UIController.changeGold(gold.ToString());
        gameController.UIController.changePower(power.ToString());

        if(hp <= 0)
        {
            SceneManager.LoadScene("Title");
        }
    }

    private void Attack()
    {
        animator.Play("attack");
        score += 10;
        gameController.EnemyDamage(power);
    }

    void OnMessageArrived(string msg)
    {
            if (canPlay)
            {
                switch (msg)
                {
                    case "Attack":
                        Attack();
                        gameController.playerTurn = false;
                        canPlay = false;
                        break;
                    case "Heal":
                        gameController.playerTurn = false;
                        canPlay = false;
                        break;
                }

            }
            else
            {
                if (msg == "Detected" && !pressed)
                {
                    Damage(20);
                }

                if (msg == "Attack" && !pressed)
                {
                    pressed = true;
                    Attack();
                    gameController.ResetEnemy();
                }
            }
        
        msgs.Add(msg);



    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }

    public void Damage(int value)
    {
        animator.Play("damage");
        hp -= value;
    }

}
