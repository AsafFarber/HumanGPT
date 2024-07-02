using UnityEngine;
using Zenject;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    [Tooltip("A ScriptableObject containing the item's data.")]
    private CollectableData collectableData;

    [Inject]
    private CollectionManager collectionManager;

    public CollectableData GetcollectableData() => collectableData;

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
