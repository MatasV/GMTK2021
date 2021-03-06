using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnvironmentSpawner : MonoBehaviour
{
    public Transform topSpawn;
    public Transform bottomSpawn;
    public Transform lineSpawn;

    public GameObject sparkles;
    public GameObject[] underwater;
    public GameObject grass;

    public float grassSpawnRate;
    private void Start()
    {
        InvokeRepeating("SpawnRipples", 0.5f, 1.5f);
        InvokeRepeating("SpawnFish", 8f, 10f);
        InvokeRepeating("SpawnGrass", 0f, grassSpawnRate);
    }

    private void SpawnFish()
    {
        int topOrBottom = Random.Range(0, 2);
        if (topOrBottom == 0)
        {
            var fishy = Instantiate(underwater[Random.Range(0, underwater.Length)], topSpawn.position, Quaternion.identity);
            fishy.transform.position = new Vector3(fishy.transform.position.x ,
                fishy.transform.position.y + Random.Range(-3, 3),
                fishy.transform.position.z);
        }
        else
        {
            var fishy = Instantiate(underwater[Random.Range(0, underwater.Length)], bottomSpawn.position, Quaternion.identity);
            
            fishy.transform.position = new Vector3(fishy.transform.position.x ,
                fishy.transform.position.y + Random.Range(-3, 3),
                fishy.transform.position.z );
        }
    }
    private void SpawnRipples()
    {
        
        var bottomSparkle = Instantiate(sparkles, bottomSpawn.position, Quaternion.Euler(0,0, Random.Range(0, 360)));
        bottomSparkle.transform.position = new Vector3(bottomSparkle.transform.position.x + Random.Range(-3, 3),
            bottomSparkle.transform.position.y + Random.Range(-3, 3),
            bottomSparkle.transform.position.z + Random.Range(-3, 3));

        bottomSparkle.transform.localScale *= Random.Range(0.8f, 1.3f);
        
        var topSparkle = Instantiate(sparkles, topSpawn.position, Quaternion.Euler(0,0, Random.Range(0, 360)));
        topSparkle.transform.position = new Vector3(topSparkle.transform.position.x + Random.Range(-3, 3),
            topSparkle.transform.position.y + Random.Range(-3, 3),
            topSparkle.transform.position.z + Random.Range(-3, 3));

        topSparkle.transform.localScale *= Random.Range(0.8f, 1.3f);
    }

    private void SpawnGrass()
    {
        var grassLine = Instantiate(grass, lineSpawn.position, Quaternion.identity, lineSpawn);
        transform.localPosition = Vector3.zero;
    }
}
