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

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeStart += Time.deltaTime;
        if(timeStart > timeLim)
        {
            SpawnEnemyBot();
            SpawnEnemyTop();
            SpawnBottomCoin();
            SpawnTopCoin();
            timeStart = 0;
        }
    }

    public void SpawnEnemyTop()
    {
        int enemyIndex = Random.Range(0, enemies.Length);
        int spawnIndexT = Random.Range(0, spawnPoints.Length - 3);
            Instantiate(enemies[enemyIndex], spawnPoints[spawnIndexT].position, Quaternion.identity, spawnPoints[spawnIndexT]);
            transform.localPosition = Vector3.zero;     

    }
    public void SpawnEnemyBot()
    {
        int enemyIndex = Random.Range(0, enemies.Length);
        int spawnIndexB = Random.Range(3, spawnPoints.Length);
            Instantiate(enemies[enemyIndex], spawnPoints[spawnIndexB].position, Quaternion.identity, spawnPoints[spawnIndexB]);
            transform.localPosition = Vector3.zero;  
    }
    public void SpawnBottomCoin()
    {
        int spawnIndexC = Random.Range(2, coinPoints.Length);
        Instantiate(bottomCoin, coinPoints[spawnIndexC].position, Quaternion.identity, coinPoints[spawnIndexC]);
        transform.localPosition = Vector3.zero;
    }
    public void SpawnTopCoin()
    {
        int spawnIndexC = Random.Range(0, coinPoints.Length - 2);
        Instantiate(topCoin, coinPoints[spawnIndexC].position, Quaternion.identity, coinPoints[spawnIndexC]);
        transform.localPosition = Vector3.zero;
    }
}
