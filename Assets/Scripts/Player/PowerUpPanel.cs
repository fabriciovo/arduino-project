
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
    private float life = 1f;
    private float attackSpeed = 1f;
    private float attackPower = 1f;
    private float xpValue = 1f;
    private Player player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame

    public void RandomPowerUp()
    {
        RandomPowerUpButton(powerup1);
        RandomPowerUpButton(powerup2);
    }

    private void AttackSpeed()
    {
        Debug.Log("AttackSpeed");
        attackSpeed = Random.Range(1, player.GetLevel()) / 3;
        player.SetAttackSpeed(attackSpeed);
        gameObject.SetActive(false);
    }
    private void Life()
    {
        Debug.Log("Life");
        life = Random.Range(1, player.GetLevel()) / 3;
        player.SetLife(life);
        gameObject.SetActive(false);
    }
    private void AttackPower()
    {
        Debug.Log("AttackPower");

        attackPower = Random.Range(1, player.GetLevel()) / 3;
        player.SetAttackPower(attackPower);
        gameObject.SetActive(false);
    }
    private void XpValue()
    {
        Debug.Log("XpValue");

        player.SetXpValue();
        gameObject.SetActive(false);
    }
    private void UpgradeShoot()
    {
        Debug.Log("UpgradeShoot");

        player.UpgradeShoot();
        gameObject.SetActive(false);
    }

    private void RandomPowerUpButton(Button powerup)
    {
        float value = Random.value;
        if (value > 0 && value < 0.3 && player.GetAttackSpeed() >= 0.5f)
        {
            powerup.GetComponentInChildren<TextMeshProUGUI>().text = "Attack Speed - " + attackSpeed.ToString();
            powerup.onClick.AddListener(AttackSpeed);
        }
        else if (value > 0.3 && value < 0.4)
        {
            powerup.GetComponentInChildren<TextMeshProUGUI>().text = "Attack Power + " + attackPower.ToString();
            powerup.onClick.AddListener(AttackPower);
        }
        else if (value > 0.5 && value < 0.6)
        {
            powerup.GetComponentInChildren<TextMeshProUGUI>().text = "Life + " + life.ToString();
            powerup.onClick.AddListener(Life);

        }
        else if (value > 0.9)
        {
            powerup.GetComponentInChildren<TextMeshProUGUI>().text = "XP value + 1";
            powerup.onClick.AddListener(XpValue);
        }
        else if (value > 0.7 && value < 0.8 && player.CanUpgradeShoot())
        {
            powerup.GetComponentInChildren<TextMeshProUGUI>().text = "Shoot + 1";
            powerup.onClick.AddListener(UpgradeShoot);
        }
        else
        {
            powerup.GetComponentInChildren<TextMeshProUGUI>().text = "No upgrade";
            powerup.onClick.RemoveAllListeners();
        }
    }

    public void Buy(string button)
    {

        if (button == "Button1")
        {
            powerup1.onClick.Invoke();
            powerup1.onClick.RemoveAllListeners();
        }
        if (button == "Button2")
        {
            powerup2.onClick.Invoke();
            powerup2.onClick.RemoveAllListeners();
        }
    }


}