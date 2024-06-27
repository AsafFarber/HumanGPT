using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour, IInteractable
{
    public abstract void Interact(Interactor PlayerInteractor);
}
