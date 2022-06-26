using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TMP_Text life;
    [SerializeField] private TMP_Text xp;
    [SerializeField] private TMP_Text level;

    // Update is called once per frame
    void Update()
    {
        life.text = "Life: " + player.GetLife().ToString();
        xp.text = "xp: " + player.GetXP().ToString() + " / " + player.GetMaxXP().ToString();
        level.text = "Level: " + player.GetLevel().ToString();
    }
    
}
