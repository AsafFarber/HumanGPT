using UnityEngine;

public class PickableItem : Item
{
    public override void Interact(Interactor playerInteractor)
    {
        GiveItemToPlayer(playerInteractor);
    }

    public void GiveItemToPlayer(Interactor playerInteractor)
    {
        playerInteractor.PickupItem(this);
    }
}
