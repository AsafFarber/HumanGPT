using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CollectableItem", menuName = "Collectable [Scriptable Object]")]
public class CollectableItem : ScriptableObject
{
    public CollectableType type;
    public Sprite image;
    public string displayName;
    public AudioClip soundEffect;
}
