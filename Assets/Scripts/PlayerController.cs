using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool canPlay = true;
    public bool endTurn = false;
    public int score = 0;
    private bool pressed = false;
    private List<string> msgs = new List<string>();
    [SerializeField] private GameController gameController;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (canPlay)
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        Attack();
        //        gameController.playerTurn = false;
        //        canPlay = false;
        //    }
        //}
        //else
        //{
        //    if (Input.GetKeyDown(KeyCode.Space) && !detected)
        //    {
        //        //Attack();

        //    }
        //}
    }

    private void Attack()
    {
        score += 10;
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
        score -= value;
    }

}
