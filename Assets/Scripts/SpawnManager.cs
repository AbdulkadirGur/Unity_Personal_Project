using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;

    private float zEnemySpawn = 10.0f;
    private float xSpawnRange = 8.0f;
    private float zPowerupRange = 2.0f;
    private float ySwapnRange = 0.75f;

    private float enemySpawnTime = 1.0f;
    private float powerUpSpawnTime = 5.0f;
    private float startDelay = 1.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy",startDelay ,enemySpawnTime);
        InvokeRepeating("SpawnPowerUp",startDelay ,powerUpSpawnTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float randSpawnX = Random.Range(xSpawnRange, -xSpawnRange);
        int randEnemy = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randSpawnX, ySwapnRange, zEnemySpawn);

        Instantiate(enemies[randEnemy],spawnPos , enemies[randEnemy].transform.rotation);



    }

    void SpawnPowerUp()
    {
        float randSpawnX = Random.Range(xSpawnRange, -xSpawnRange);
        float randSpawnZ = Random.Range(zPowerupRange, -zPowerupRange);

        Vector3 spawnPos = new Vector3(randSpawnX, ySwapnRange, randSpawnZ);  

        Instantiate(powerup,spawnPos , powerup.transform.rotation);
    }
}
