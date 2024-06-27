using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PrefabPoolSpawner : MonoBehaviour
{
    [Inject]
    private IterationManager iterationManager;

    [SerializeField] private PrefabPool pool;
    [SerializeField] private bool spawnAtNewIteration = false;
    [SerializeField] private bool spawnAtStart = false;

    void Start()
    {
        if (spawnAtNewIteration)
            iterationManager.OnIterationInitialize += Spawn;
        if (spawnAtStart)
            Spawn();
    }
    void OnDestroy()
    {
        iterationManager.OnIterationInitialize -= Spawn;
    }
    public void Spawn()
    {
        if (pool.IsFull())
        {
            return;
        }

        GameObject obj = pool.GetObject();
        obj.transform.SetParent(transform);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localEulerAngles = Vector3.zero;
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
