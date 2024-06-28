using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;
public class PrefabPool : MonoBehaviour
{
    [Inject]
    private DiContainer container;

    [SerializeField] private GameObject prefab;
    [SerializeField] private int defaultAmount = 0;
    [SerializeField] private int maximumAmount = 60;

    private IObjectPool<GameObject> pool;
    private int objectCounter = 0;
    void Awake()
    {
        objectCounter = defaultAmount;
        pool = new ObjectPool<GameObject>(CreateObjectForPool, OnGetFromPool, OnReleaseToPool);
        for (int i = 0; i < defaultAmount; i++)
        {
            pool.Release(CreateObjectForPool());
        }
    }
    public GameObject GetObject()
    {
        return pool.Get();
    }
    public bool IsFull()
    {
        return objectCounter >= maximumAmount;
    }
    private GameObject CreateObjectForPool()
    {
        GameObject obj = container.InstantiatePrefab(prefab);
        obj.AddComponent<PooledObject>().AssignPool(pool);
        return obj;
    }
    private void OnGetFromPool(GameObject obj)
    {
        obj.SetActive(true);
        objectCounter++;
    }
    private void OnReleaseToPool(GameObject obj)
    {
        obj.SetActive(false);
        objectCounter--;
    }
}
