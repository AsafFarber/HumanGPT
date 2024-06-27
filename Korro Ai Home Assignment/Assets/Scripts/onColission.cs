using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class onColission : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private UnityEvent onCollisionEnter;

    private void OnCollisionEnter(Collision collision)
    {
        if ((layerMask & (1 << collision.gameObject.layer)) != 0)
        {
            onCollisionEnter.Invoke();
        }
    }
}
