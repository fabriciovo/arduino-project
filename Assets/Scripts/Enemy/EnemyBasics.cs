using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasics : MonoBehaviour
{
    private float life = 1;
    private float damage = 1;
    private Player player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        life = Random.Range(1, player.GetLevel());
        damage = Random.Range(1, player.GetLevel());
    }
    void OnDestroy()
    {
        if (!player) return;
        player.UpdateXP();
    }
}
