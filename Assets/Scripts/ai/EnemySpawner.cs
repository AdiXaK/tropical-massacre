using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

[System.Serializable]
public class SpawnObject
{
    public GameObject prefab;
    public float spawnChance;
    public float spawnDistance;
    public ObjectPool objectPool; // New property to store the object pool
}

public class EnemySpawner : MonoBehaviour
{
    public List<SpawnObject> spawnObjects;
    public float spawnInterval = 4f;
    public int enemyCount = 1;
    public int enemyIncreaseAmount = 4;

    private Coroutine spawnCoroutine;

    private void Start()
    {
        foreach (SpawnObject spawnObject in spawnObjects)
        {
            ObjectPool objectPool = new ObjectPool(spawnObject.prefab, 50);
            spawnObject.objectPool = objectPool;
        }

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
                    GameObject spawnedEnemy = spawnObject.objectPool.GetObjectFromPool();

                    if (spawnedEnemy != null)
                    {
                        spawnedEnemy.transform.position = hit.position;
                        spawnedEnemy.SetActive(true);
                    }
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
