using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OnTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private UnityEvent<GameObject> onTriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if ((layerMask & (1 << other.gameObject.layer)) != 0)
        {
            onTriggerEnter.Invoke(other.gameObject);
        }
    }
}
