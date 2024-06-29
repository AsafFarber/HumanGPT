using UnityEngine;

[CreateAssetMenu(fileName = "CollectableItem", menuName = "Collectable [Scriptable Object]")]
public class CollectableItem : ScriptableObject
{
    [Tooltip("Type of the collectable item.")]
    public CollectableType type;

    [Tooltip("Image representing the collectable item.")]
    public Sprite image;

    [Tooltip("Display name of the collectable item.")]
    public string displayName;

    [Tooltip("Sound effect played when the item is collected.")]
    public AudioClip soundEffect;

    [Tooltip("Sound effect played when the item is collected.")]
    public ParticleSystem visualEffect;
}
