using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class Destroyer : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private void OnTriggerEnter(Collider other)
    {
        if ((layerMask & (1 << other.gameObject.layer)) != 0)
        {
            PooledObject pooledObject = other.GetComponent<PooledObject>();
            if (pooledObject != null)
            {
                pooledObject.ReleaseToPool();
            }
            else
                Destroy(other.gameObject);
        }
    }
}
