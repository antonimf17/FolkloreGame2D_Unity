using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeRandom : MonoBehaviour
{
    [SerializeField] GameObject spawnObject; //Prefab del objeto a instanciar
    public float spawnInitialDelay = 4f; //Timepo de espera hasta la primera instancia de repetición
    public float spawnRate = 2f; //Lapso de tiempo entre instanciaciones

    [SerializeField] bool isRandom;
    [SerializeField] float randomLimitY;
    [SerializeField] float randomLimitX;

    // Start is called before the first frame update
    void Start()
    {
        if (isRandom) InvokeRepeating(nameof(RandomSpawner), spawnInitialDelay, spawnRate); //Método de spawn random
        else InvokeRepeating(nameof(Spawner), spawnInitialDelay, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        float randomPosX = Random.Range(-randomLimitX, randomLimitX);
        Vector3 randomizedPos = new Vector3(randomPosX, randomPosY, 0);
        Instantiate(spawnObject, randomizedPos, Quaternion.identity);
    }
}
