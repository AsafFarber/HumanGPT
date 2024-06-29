using UnityEngine;
using Zenject;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    private CollectableType type;

    [SerializeField]
    private ParticleSystem visualEffect;

    [Inject]
    private CollectionManager collectionManager;

    public CollectableType GetCollectableType() => type;

    public void Collect()
    {
        collectionManager.AddCollectable(this);
        
        PooledObject pooledObject = GetComponent<PooledObject>();
        if (pooledObject != null)
        {
            pooledObject.ReleaseToPool();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
