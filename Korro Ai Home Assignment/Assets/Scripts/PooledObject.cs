using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PooledObject : MonoBehaviour
{
    private IObjectPool<GameObject> pool;

    public void AssignPool(IObjectPool<GameObject> poolToAssign)
    {
        pool = poolToAssign;
    }
    public void ReleaseToPool()
    {
        pool.Release(gameObject);
    }
}
