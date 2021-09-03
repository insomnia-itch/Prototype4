using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRange = 9;

    public int enemyCount;
    public int wave = 1;

    public GameObject[] powerupPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        int randomPowerup = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[randomPowerup], GenerateSpawnPosition(),
        powerupPrefabs[randomPowerup].transform.rotation);

        SpawnEnemyWave(wave);
        //Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            wave++;
            SpawnEnemyWave(wave);
            int randomPowerup = Random.Range(0, powerupPrefabs.Length);
            GameObject enemy = Instantiate(powerupPrefabs[randomPowerup], GenerateSpawnPosition(), powerupPrefabs[randomPowerup].transform.rotation);
            enemy.GetComponent<Enemy>().speed *= wave;
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
    void SpawnEnemyWave(int numOfEnemies)
    {
        for (int i = 0; i < numOfEnemies; i++)
        {
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Vector3 randomPos = GenerateSpawnPosition();
            Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);
        }
    }
}
