using UnityEngine;
using Zenject;
using UnityEngine.Events;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField]
    private UnityEvent OnInteractWithKey;
    [SerializeField]
    private UnityEvent OnInteractWithotKey;
    [Inject]
    private CollectionManager collectionManager;

    public void Interact(Interactor interactor)
    {
        if (collectionManager.GetCollectableAmount(CollectableType.Key) > 0)
        {
            OnInteractWithKey?.Invoke();
        }
        else
        {
            OnInteractWithotKey?.Invoke();
        }
    }
}
