using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] private TMP_Text ringsText;
    [SerializeField] private TMP_Text timerText;

    [SerializeField] private Player player;
    [SerializeField] float timer = 60f;
    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            timer = 0;
            //player.GameOver();
        }
        ringsText.text = "Rings: " + player.rings.ToString();
        timerText.text = "Timer: " + Mathf.FloorToInt(timer % 60); ;
    }
}
