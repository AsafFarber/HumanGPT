using UnityEngine;

public class EmptyItem : Item
{
    public override void Interact(Interactor playerInteractor)
    {
        Debug.LogWarning("Interact method not implemented for EmptyItem.");
        throw new System.NotImplementedException();
    }
}
