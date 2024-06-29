using UnityEngine;
using Zenject;
using UnityEngine.Events;

public class PrefabPoolSpawner : MonoBehaviour
{
    [Inject]
    private IterationManager iterationManager;

    [SerializeField]
    private PrefabPool pool;

    [SerializeField]
    private bool spawnOnNewIteration = false;

    [SerializeField]
    private bool spawnOnStart = false;

    [SerializeField]
    private UnityEvent OnSpawn;

    private void Start()
    {
        if (spawnOnNewIteration)
        {
            iterationManager.OnIterationInitialize += Spawn;
        }
        
        if (spawnOnStart)
        {
            Spawn();
        }
    }

    private void OnDestroy()
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

        OnSpawn?.Invoke();
    }
}
