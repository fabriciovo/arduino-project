using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject enemy3;

    [SerializeField] private GameObject rings;

    private Vector3 terrainRandomPos;
    private GameObject enemy;
    private GameObject playerHelp;
    private float spawnTime = 10f;

    private float delay;


    private float randomWidth;
    private float randomLenght;
    //private Animator anim;

    void Update()
    {

        if (Random.value > 0.5)
        {
            enemy = enemy1;
        }
        else
        {
            if (Random.value > 0.5)
            {
                enemy = enemy2;
            }
            else
            {
                enemy = enemy2;
            }
        }
        if (Random.value > 0.3)
        {
            playerHelp = rings;
        }

        CreateEnemy();
        CreatePlayerStuff();


    }

    private void CreateEnemy()
    {
        delay -= Time.deltaTime;

        if (delay <= 0 && Time.timeScale > 0)
        {
            delay = spawnTime;

            randomLenght = Random.Range(4, 40);
            randomWidth = Random.Range(4, 40);

            terrainRandomPos = new Vector3(randomWidth, 0.4f, randomLenght);
            Instantiate(enemy, terrainRandomPos, Quaternion.identity);
        }
    }
    private void CreatePlayerStuff()
    {
        delay -= Time.deltaTime;
        if (delay <= 0 && Time.timeScale > 0)
        {
            delay = spawnTime;

            randomLenght = Random.Range(4, 54);
            randomWidth = Random.Range(4, 74);

            terrainRandomPos = new Vector3(randomWidth, 0.5f, randomLenght);
            Instantiate(playerHelp, terrainRandomPos, Quaternion.identity);
        }


    }

}
