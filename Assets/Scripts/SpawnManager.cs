using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;

    public int enemyCount;
    public int wave = 1;

    public GameObject powerupPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(wave);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            wave++;
            SpawnEnemyWave(wave);
            GameObject enemy = Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            enemy.GetComponent<EnemyX>().speed *= wave;
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
            Vector3 randomPos = GenerateSpawnPosition();
            Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);
        }
    }
}
