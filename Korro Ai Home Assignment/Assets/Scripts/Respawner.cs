using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class Respawner : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    [Inject]
    private IterationManager iterationManager;

    private void OnTriggerEnter(Collider other)
    {
        if ((layerMask & (1 << other.gameObject.layer)) != 0)
        {
            if (other.gameObject.GetComponent<PlayerControls>() != null)
            {
                iterationManager.InitializeIteration();
            }
        }
    }
}
