using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoints;

    public GameObject topCoin;
    public GameObject bottomCoin;
    public Transform[] coinPoints;

    private float timeStart = 0;
    public float timeLim;

    public GameObject mine;

    public float mineTime;
    public float mineTimer;
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timeStart += Time.deltaTime;
        mineTimer += Time.deltaTime;
        if (mineTimer > mineTime)
        {
            SpawnMine();
            mineTimer = 0;
        }
        if(timeStart > timeLim)
        {
            SpawnEnemyBot();
            SpawnEnemyTop();
            SpawnBottomCoin();
            SpawnTopCoin();
            timeStart = 0;
        }
    }

    private void SpawnMine()
    {
        int spawnIndexB = Random.Range(3, spawnPoints.Length);
        Instantiate(mine, spawnPoints[spawnIndexB].position, Quaternion.identity, spawnPoints[spawnIndexB]);

        int spawnIndexT = Random.Range(0, spawnPoints.Length - 3);
        Instantiate(mine, spawnPoints[spawnIndexT].position, Quaternion.identity, spawnPoints[spawnIndexT]);
    }

    public void SpawnEnemyTop()
    {
        int enemyIndex = Random.Range(0, enemies.Length);
        int spawnIndexT = Random.Range(0, spawnPoints.Length - 3);
            Instantiate(enemies[enemyIndex], spawnPoints[spawnIndexT].position, Quaternion.identity, spawnPoints[spawnIndexT]);
    }
    public void SpawnEnemyBot()
    {
        int enemyIndex = Random.Range(0, enemies.Length);
        int spawnIndexB = Random.Range(3, spawnPoints.Length);
            Instantiate(enemies[enemyIndex], spawnPoints[spawnIndexB].position, Quaternion.identity, spawnPoints[spawnIndexB]);
    }
    public void SpawnBottomCoin()
    {
        int spawnIndexC = Random.Range(2, coinPoints.Length);
        Instantiate(bottomCoin, coinPoints[spawnIndexC].position, Quaternion.identity, coinPoints[spawnIndexC]);
    }
    public void SpawnTopCoin()
    {
        int spawnIndexC = Random.Range(0, coinPoints.Length - 2);
        Instantiate(topCoin, coinPoints[spawnIndexC].position, Quaternion.identity, coinPoints[spawnIndexC]);
    }
}
