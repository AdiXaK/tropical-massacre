using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

[System.Serializable]
public class SpawnObject
{
    public GameObject prefab;
    public float spawnChance;
    public float spawnDistance;
}

public class EnemySpawner : MonoBehaviour
{
    public List<SpawnObject> spawnObjects;
    public float spawnInterval = 4f;
    public int enemyCount = 1;
    public int enemyIncreaseAmount = 4;

    private ObjectPool enemyPool;
    private Coroutine spawnCoroutine;

    private void Start()
    {
        enemyPool = new ObjectPool(spawnObjects[0].prefab, 50);
        spawnCoroutine = StartCoroutine(SpawnEnemiesWithProgression());
    }

    private void OnDestroy()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
    }

    private System.Collections.IEnumerator SpawnEnemiesWithProgression()
    {
        while (true)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            for (int i = 0; i < enemyCount; i++)
            {
                SpawnObject spawnObject = GetRandomSpawnObject();

                Vector3 randomSpawnPoint = player.transform.position + Random.insideUnitSphere * spawnObject.spawnDistance;

                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomSpawnPoint, out hit, 10f, NavMesh.AllAreas))
                {
                    GameObject spawnedEnemy = enemyPool.GetObjectFromPool();

                    if (spawnedEnemy != null)
                    {
                        spawnedEnemy.transform.position = hit.position;
                        spawnedEnemy.SetActive(true);
                    }
                }
                else
                {
                    Debug.LogWarning("Failed to find a valid point on the navigation mesh for enemy spawn.");
                }
            }
            enemyCount += enemyIncreaseAmount;
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private SpawnObject GetRandomSpawnObject()
    {
        float totalSpawnChance = 0f;
        foreach (SpawnObject spawnObject in spawnObjects)
        {
            totalSpawnChance += spawnObject.spawnChance;
        }

        float randomValue = Random.Range(0f, totalSpawnChance);
        float cumulativeChance = 0f;

        foreach (SpawnObject spawnObject in spawnObjects)
        {
            cumulativeChance += spawnObject.spawnChance;
            if (randomValue <= cumulativeChance)
            {
                return spawnObject;
            }
        }

        return spawnObjects[0];
    }
}
