using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
    public TMP_Text score;
    [SerializeField] private Player playerScore;

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + playerScore.score.ToString();
    }
}
