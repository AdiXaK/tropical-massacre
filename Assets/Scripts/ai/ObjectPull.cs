using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private List<GameObject> pool;
    private GameObject prefab;

    public ObjectPool(GameObject prefab, int initialSize)
    {
        this.prefab = prefab;
        pool = new List<GameObject>();

        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = CreateObject();
            pool.Add(obj);
        }
    }

    public GameObject GetObjectFromPool()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeSelf)
            {
                return obj;
            }
        }

        GameObject newObj = CreateObject();
        pool.Add(newObj);
        return newObj;
    }

    public void DisableObjectsInPool()
    {
        foreach (GameObject obj in pool)
        {
            obj.SetActive(false);
        }
    }

    private GameObject CreateObject()
    {
        GameObject obj = GameObject.Instantiate(prefab);
        obj.SetActive(false);
        return obj;
    }
}
