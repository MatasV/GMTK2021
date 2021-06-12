using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoints;

    private float timeStart = 0;
    public float timeLim;

    void Start()
    {
        Invoke("SpawnEnemyTop", 1f);
        Invoke("SpawnEnemyBot", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        timeStart += Time.deltaTime;
        if(timeStart > timeLim)
        {
            Invoke("SpawnEnemyTop", 1f);
            Invoke("SpawnEnemyBot", 1f);
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
}
