using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn Configurations")]
    [SerializeField] GameObject spawnObject; //Prefab del objeto a instanciar
    public float spawnInitialDelay = 4f; //Timepo de espera hasta la primera instancia de repetición
    public float spawnRate = 2f; //Lapso de tiempo entre instanciaciones

    [Header("Randomizer Configuration")]
    [SerializeField] bool isRandom;
    [SerializeField] float randomLimitY;


    void Start()
    {
        if (isRandom) InvokeRepeating(nameof(RandomSpawner), spawnInitialDelay, spawnRate); //Método de spawn random
        else InvokeRepeating(nameof(Spawner), spawnInitialDelay, spawnRate);
        //InvokeRepeating(NOMBRE DE MÉTODO + TIEMPO INICIAL + TIEMPO DE REPETICIÓN)
    }

    void Spawner()
    {
        //Instanciar una copia del objeto asignado en spawnObject
        //Instantiate(PREFAB + POSITION + ROTATION)
        Instantiate(spawnObject, transform.position, Quaternion.identity);
    }
    void RandomSpawner()
    {
        float randomPosY = Random.Range(-randomLimitY, randomLimitY);
        Vector3 randomizedPos = new Vector3(transform.position.x, randomPosY, 0);
        Instantiate(spawnObject, randomizedPos, Quaternion.identity);
    }
}
