using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InteractablesDetector : MonoBehaviour
{
    [SerializeField]
    private Interactor interactor;

    private List<IInteractable> currentCollisions = new();

    [Inject]
    private IterationManager iterationManager;

    private void OnEnable()
    {
        iterationManager.OnIterationInitialize += ResetList;
    }

    private void OnDisable()
    {
        iterationManager.OnIterationInitialize -= ResetList;
    }

    private void OnTriggerEnter(Collider col)
    {
        IInteractable interactable = col.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactor.SetInteractable(interactable);
            currentCollisions.Add(interactable);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        IInteractable interactable = col.GetComponent<IInteractable>();
        if (interactable != null)
        {
            RemoveItemFromList(interactable);
        }
    }

    public void RemoveItemFromList(IInteractable interactable)
    {
        currentCollisions.Remove(interactable);
        if (currentCollisions.Count == 0)
        {
            interactor.SetInteractable(null);
        }
    }

    public void RefreshInteractablesList()
    {
        ResetList();
        GetComponent<Collider>().enabled = false;
        StartCoroutine(EnableColliderNextFrame());
    }

    private void ResetList()
    {
        currentCollisions.Clear();
    }

    private IEnumerator EnableColliderNextFrame()
    {
        yield return null;
        GetComponent<Collider>().enabled = true;
    }
}
