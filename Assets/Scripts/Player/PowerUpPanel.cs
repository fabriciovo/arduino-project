using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class PowerUpPanel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button powerup1;
    [SerializeField] private Button powerup2;
    private Button[] powerup;
    private float life = 1f;
    private float attackSpeed = 1f;
    private float attackPower = 1f;
    private float xpValue = 1f;
    private Player player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame

    public void RandomPowerUp()
    {
        powerup1.onClick.AddListener(AttackSpeed);
        powerup2.onClick.AddListener(AttackSpeed);
    }

    private void AttackSpeed()
    {
        attackSpeed = Random.Range(1, player.GetLevel()) / 3;
        player.SetAttackSpeed(attackSpeed);
        powerup1.GetComponentInChildren<TextMeshProUGUI>().text = "attackSpeed + " + attackSpeed.ToString();
        gameObject.SetActive(false);
    }
    private void Life()
    {
        life = Random.Range(1, player.GetLevel());
    }
    private void AttackPower()
    {
        attackPower = Random.Range(1, player.GetLevel());
    }
    private void XpValue()
    {
        xpValue = Random.Range(1, player.GetLevel());
    }
    private void Hide()
    {

    }
}
