using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rigidbody;
    float gravityForce = 10f;
    private bool grounded = true;
    public LayerMask whatIsGround;
    public float groundRayLenght;
    public Transform groundRayPoint;

    private float vSpeed;
    private float hSpeed;
    private bool isArduino = false;
    private float cd = 0;
    //Power Ups
    [SerializeField] private GameObject[] shoot;
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject bomb;
    [SerializeField] private GameObject effect;
    private GameObject powerUpPanel;

    //Stats
    private float speed = 20f;
    private float life = 3;
    private float xp = 0;
    private float xpMax = 3;
    private float level = 1;
    private float attackSpeed = 3f;
    private float attackPower = 0.5f;
    private float xpValue = 1;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        powerUpPanel = GameObject.Find("Panel");
        Debug.Log(powerUpPanel);
    }

    void Update()
    {
        if (!isArduino)
        {
            DesktopMovement();
        }
        Shoot();
    }
    private void Shoot()
    {
        cd -= Time.deltaTime;
        if (cd <= 0)
        {
            for (int i = 0; i < shoot.Length; i++)
            {
                if (shoot[i] != null)
                {
                    GameObject newBullet = Instantiate(shoot[i], transform.position, transform.rotation);
                    if (i == 0)
                    {
                        newBullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                            (3000f, 0, 0));
                    }
                    else if (i == 1)
                    {
                        newBullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                            (-3000f, 0, 0));
                    }
                    else if (i == 2)
                    {
                        newBullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                            (0, 0, 3000f));
                    }
                    else if (i == 3)
                    {
                        newBullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                            (0, 0, -3000f));
                    }
                    Destroy(newBullet, 5f);
                }
            }
            cd = attackSpeed;
        }
    }
    private void FixedUpdate()
    {
        grounded = false;
        RaycastHit hit;

        if (Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLenght, whatIsGround))
        {
            grounded = true;
        }

        if (grounded)
        {

            rigidbody.drag = 4f;
            if (Mathf.Abs(vSpeed) > 0 || Mathf.Abs(hSpeed) > 0)
            {
                rigidbody.AddForce(new Vector3(vSpeed, 0.0f, hSpeed * -1) * 0.5f);
            }

        }
        else
        {
            rigidbody.drag = 2f;
            if (Mathf.Abs(vSpeed) > 0 || Mathf.Abs(hSpeed) > 0)
            {
                rigidbody.AddForce(new Vector3(vSpeed, -gravityForce, hSpeed * -1) * 0.5f);
            }
        }



        if (life <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Title");

        }
    }

    private void ArduinoMovement(string msg)
    {
        if (msg == "L")
        {
            vSpeed = 1 * speed * 100f;

        }
        else if (msg == "R")
        {
            vSpeed = -1 * speed * 100f;

        }
        else if (msg == "D")
        {
            hSpeed = -1 * speed * 100f;

        }
        else if (msg == "U")
        {
            hSpeed = 1 * speed * 100f;
        }
        if (msg == "Button1")
        {
            powerUpPanel.GetComponent<PowerUpPanel>().Buy("Button1");

        }
        if (msg == "Button2")
        {
            powerUpPanel.GetComponent<PowerUpPanel>().Buy("Button2");
        }
    }

    private void DesktopMovement()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            vSpeed = Input.GetAxis("Vertical") * speed * 1000f;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            vSpeed = Input.GetAxis("Vertical") * speed * 1000f;

        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            hSpeed = Input.GetAxis("Horizontal") * speed * 1000f;

        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            hSpeed = Input.GetAxis("Horizontal") * speed * 1000f;
        }
        if (Input.GetButtonDown("Jump"))
        {
            UpdateXP();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            life--;
            Destroy(other.gameObject);
            Instantiate(effect, transform.position, transform.rotation);

        }
        if (other.tag == "Xp")
        {
            UpdateXP();
        }
    }

    void OnMessageArrived(string msg)
    {
        Debug.Log("Message: " + msg);
        ArduinoMovement(msg);
    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }

    public float GetLife()
    {
        return life;
    }
    public float GetLevel()
    {
        return level;
    }
    public float GetXP()
    {
        return xp;
    }
    public float GetMaxXP()
    {
        return xpMax;
    }

    public float GetAttackSpeed()
    {
        return attackSpeed;
    }

    public float GetAttackPower()
    {
        return attackPower;
    }

    public void UpdateXP()
    {
        xp += xpValue;
        if (xp >= xpMax)
        {
            level++;
            xp = 0;
            xpMax = xpMax * 2;
            PowerUp();
        };
    }

    public void PowerUp()
    {
        powerUpPanel.SetActive(true);
        powerUpPanel.GetComponent<PowerUpPanel>().RandomPowerUp();
    }

    public void SetAttackSpeed(float value)
    {
        Debug.Log("value " + value.ToString());
        float calc = attackSpeed - value;
        if (calc >= .5f)
        {
            attackSpeed = attackSpeed - value;
        }

        Debug.Log("attackSpeed " + attackSpeed.ToString());
    }

    public void SetLife(float value)
    {
        life += value;
    }
    public void SetAttackPower(float value)
    {
        attackPower += value;
    }

    public bool CanUpgradeShoot()
    {
        for (int i = 0; i < shoot.Length; i++)
        {
            if (shoot[i] == null) return true;

        }

        return false;
    }

    public void SetXpValue()
    {
        xpValue++;
    }
    public void UpgradeShoot()
    {
        for (int i = 0; i < shoot.Length; i++)
        {
            if (shoot[i] == null)
            {
                shoot[i] = shoot[0];
                return;
            }
        }
    }

}
