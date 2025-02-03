using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionSpawn : MonoBehaviour
{
    [Header("Spawn Configurations")]
    [SerializeField] GameObject spawnObject;
    public float spawnInitialDelay = 3f;
    public float spawnRate = 0.6f;

    [Header("Randomizer Configuration")]
    [SerializeField] bool isRandom;
    [SerializeField] float randomLimitY;


    void Start()
    {
        if (isRandom) InvokeRepeating(nameof(RandomSpawner), spawnInitialDelay, spawnRate);
        else InvokeRepeating(nameof(Spawner), spawnInitialDelay, spawnRate);
    }

    void Spawner()
    {
        Instantiate(spawnObject, transform.position, Quaternion.identity);
    }
    void RandomSpawner()
    {
        float randomPosY = Random.Range(-randomLimitY, randomLimitY);
        Vector3 randomizedPos = new Vector3(transform.position.x, randomPosY, 0);
        Instantiate(spawnObject, randomizedPos, Quaternion.identity);
    }
}
