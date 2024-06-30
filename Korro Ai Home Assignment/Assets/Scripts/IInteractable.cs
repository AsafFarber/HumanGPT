using UnityEngine;

public interface IInteractable
{
    GameObject gameObject { get; }
    void Interact(Interactor playerInteractor);
    public void AddOutline()
    {
        if (gameObject == null)
        {
            return;
        }

        Outline outline = gameObject.GetComponent<Outline>();
        if (outline == null)
        {
            gameObject.AddComponent<Outline>();

        }
    }
    public void RemoveOutline()
    {
        if (gameObject == null)
        {
            return;
        }

        Outline outline = gameObject.GetComponent<Outline>();
        if (outline != null)
        {
            Object.Destroy(outline);
        }
    }
}