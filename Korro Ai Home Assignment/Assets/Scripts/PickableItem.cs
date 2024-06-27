using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : Item
{
    public override void Interact(Interactor PlayerInteractor)
    {
        GiveItemToPlayer(PlayerInteractor);
    }
    public void GiveItemToPlayer(Interactor PlayerInteractor)
    {
        PlayerInteractor.PickupItem(this);
    }
}
