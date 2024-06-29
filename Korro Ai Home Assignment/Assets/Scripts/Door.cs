using UnityEngine;
using Zenject;
using UnityEngine.Events;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField]
    private UnityEvent OnDoorOpen;

    [Inject]
    private CollectionManager collectionManager;

    public void Interact(Interactor interactor)
    {
        if (collectionManager.GetCollectableAmount(CollectableType.Key) > 0)
        {
            OnDoorOpen.Invoke();
        }
    }
}
