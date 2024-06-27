using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Collectable : MonoBehaviour
{
    [SerializeField] private CollectableType type;
    [SerializeField] private ParticleSystem visualEffect;
    public CollectableType GetCollectableType() => type;
    [Inject]
    private CollectionManager collectionManager;
    public void Collect()
    {
        collectionManager.AddCollectable(type);
        GameObject vfx = Instantiate(visualEffect.gameObject);
        vfx.transform.position = transform.position;

        PooledObject pooledObject = GetComponent<PooledObject>();
        if (pooledObject != null)
            pooledObject.ReleaseToPool();
        else
            gameObject.SetActive(false);
    }
}
