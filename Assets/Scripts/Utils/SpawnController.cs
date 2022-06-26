using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject enemy3;

    [SerializeField] private GameObject rings;
    [SerializeField] private GameObject[] enviroment;
    private Vector3 terrainRandomPos;
    private GameObject enemy;
    private GameObject playerHelp;
    private float spawnTime = 1f;

    private float delay;


    private float randomWidth;
    private float randomLenght;
    //private Animator anim;

    void Start()
    {
        for (int i = 0; i < 600; i++)
        {
            randomLenght = Random.Range(-447, 447);
            randomWidth = Random.Range(-447, 447);
            terrainRandomPos = new Vector3(randomWidth, 0.5f, randomLenght);
            int value = Random.Range(0, 5);
            Instantiate(enviroment[value],terrainRandomPos,Quaternion.identity);
        }
    }

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

            randomLenght = Random.Range(-400, 400);
            randomWidth = Random.Range(-400, 400);

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

            randomLenght = Random.Range(-400, 400);
            randomWidth = Random.Range(-400, 400);

            terrainRandomPos = new Vector3(randomWidth, 0.5f, randomLenght);
            Instantiate(playerHelp, terrainRandomPos, Quaternion.identity);
        }


    }

}
