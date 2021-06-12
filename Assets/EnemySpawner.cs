using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemyTop", 1f);
        Invoke("SpawnEnemyBot", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemyTop()
    {
        int enemyIndex = Random.Range(0, enemies.Length);
        int spawnIndexT = Random.Range(0, spawnPoints.Length - 3);

        Instantiate(enemies[enemyIndex], spawnPoints[spawnIndexT]);
    }
    void SpawnEnemyBot()
    {
        int enemyIndex = Random.Range(0, enemies.Length);
        int spawnIndexB = Random.Range(3, spawnPoints.Length);
        Instantiate(enemies[enemyIndex], spawnPoints[spawnIndexB]);
    }
}
