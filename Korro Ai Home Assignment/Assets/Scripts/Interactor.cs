using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using Zenject;
/// <summary>
/// Manages interactions and item handling for the player.
/// </summary>
public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform itemInHandContainer;
    [SerializeField] private InteractablesDetector detector;
    [SerializeField] private PlayerAnimation playerAnimation;
    [SerializeField] private UnityEvent OnItemTake;
    [SerializeField] private UnityEvent OnItemDrop;
    private IInteractable currentInteractable = null;

    [Inject]
    private IterationManager iterationManager;
    void OnEnable()
    {
        iterationManager.OnIterationInitialize += DropItem;
        iterationManager.OnIterationInitialize += SetInteractableToNull;
    }
    void OnDisable()
    {
        iterationManager.OnIterationInitialize -= DropItem;
        iterationManager.OnIterationInitialize -= SetInteractableToNull;
    }
    public void IteractButton(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        if (currentInteractable == null)
        {
            DropItem();
        }
        else
        {
            currentInteractable.Interact(this);
            SetInteractableToNull();
            detector.RefreshInteractablesList();
        }
    }
    void SetInteractableToNull()
    {
        currentInteractable = null;
    }
    public void SetInteractable(IInteractable newInteractable)
    {
        currentInteractable = newInteractable;
    }
    public void PickupItem(Item item)
    {
        if (IsCarryingObject())
        {
            DropItem();
            return;
        }

        PrepareItemForPickup(item);
        item.transform.localPosition = Vector3.zero;
        item.transform.localEulerAngles = Vector3.zero;
        playerAnimation.CarryAnimation(true);
        OnItemTake?.Invoke();
    }
    public void DropItem()
    {
        if (!IsCarryingObject()) return;

        Transform item = itemInHandContainer.GetChild(0);
        ResetItemAfterDrop(item);
        playerAnimation.CarryAnimation(false);
        SetInteractableToNull();
        OnItemDrop?.Invoke();
    }
    private bool IsCarryingObject()
    {
        return itemInHandContainer.childCount != 0;
    }
    private void PrepareItemForPickup(Item item)
    {
        Rigidbody itemRigidBody = item.GetComponent<Rigidbody>();
        if (itemRigidBody != null)
        {
            itemRigidBody.useGravity = false;
            itemRigidBody.constraints = RigidbodyConstraints.FreezeAll;
        }
        item.GetComponent<Collider>().enabled = false;
        item.transform.SetParent(itemInHandContainer);
    }
    private void ResetItemAfterDrop(Transform item)
    {
        Rigidbody itemRigidBody = item.GetComponent<Rigidbody>();
        if (itemRigidBody != null)
        {
            itemRigidBody.useGravity = true;
            itemRigidBody.constraints = RigidbodyConstraints.FreezeRotation;
        }
        item.GetComponent<Collider>().enabled = true;
        item.transform.SetParent(null);
    }
}
