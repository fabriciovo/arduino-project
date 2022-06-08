 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool canPlay = false;
    public int hp = 200;
    private int level = 1;
    private int damage = 1;  
    private float timeRemaining = 10.0f;
    private float timer = 10.0f;
    private Animator animator;

    private GameController gameController;

    private SpriteRenderer spriteRenderer;
    public Sprite deadSprite;
    public Sprite enemySprite;
    public bool dead = false;

    // Update is called once per frame
    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    void Update()
    {
        if (canPlay)
        {
            animator.Play("enemy_idle_turn");

            if (timeRemaining > 0)
            {

                timeRemaining -= Time.deltaTime;
            }
            else
            {
                animator.Play("enemy_attack");

                Attack();
            }
        }
        gameController.UIController.changeEnemyHp(hp.ToString());
        gameController.UIController.changeEnemyLevel(level.ToString());
        if (hp <= 0)
        {
            canPlay = false;
            dead = true;
            animator.enabled = false;
            spriteRenderer.sprite = deadSprite;
        }
        else
        {
            dead = false;
            animator.enabled = true;
            spriteRenderer.sprite = enemySprite;
        }
    }

    private void Attack()
    {
        Debug.Log("Enemy attack");

        canPlay = false;

       
        timeRemaining = timer;

    
        gameController.playerTurn = true;
        gameController.PlayerDamage(damage);
        
    }
    public void ResetEnemy()
    {
        canPlay = false;
        gameController.playerTurn = true;
        timeRemaining = timer;
        animator.Play("enemy_idle");
    }
    public void Damage(int value)
    {
        hp -= value;
        animator.Play("enemy_damage");
    }

    public void newEnemy()
    {
        level++;
        hp = 10 * level;
        damage = 1 * level;
    }
}
