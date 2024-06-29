using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CollectionManager : MonoBehaviour
{
    [SerializeField]
    private CollectableDisplay collectionDisplay;

    [SerializeField]
    private CollectableItem[] collectableItemsData;

    [SerializeField]
    private AudioSource audioSource;

    [Inject]
    private IterationManager iterationManager;

    private readonly Dictionary<CollectableType, int> collectables = new Dictionary<CollectableType, int>();
    private readonly Dictionary<CollectableType, CollectableDisplay> displays = new Dictionary<CollectableType, CollectableDisplay>();

    private void Start()
    {
        CreateUI();
        ResetCollection();
        iterationManager.OnIterationInitialize += ResetCollection;
    }

    private void OnDestroy()
    {
        iterationManager.OnIterationInitialize -= ResetCollection;
    }

    public void AddCollectable(Collectable collectable)
    {
        CollectableType type = collectable.GetCollectableType();
        collectables[type]++;
        foreach (CollectableItem itemData in collectableItemsData)
        {
            if (itemData.type == type)
            {
                displays[type].AddCollectableGraphic(itemData.image);
                Instantiate(itemData.visualEffect.gameObject, collectable.transform.position, Quaternion.identity);
                audioSource.PlayOneShot(itemData.soundEffect);
            }
        }
    }

    public void ResetCollection()
    {
        collectables.Clear();
        foreach (CollectableType type in Enum.GetValues(typeof(CollectableType)))
        {
            collectables[type] = 0;
            displays[type].ResetCollectableDisplay();
        }
    }

    public int GetCollectableAmount(CollectableType type)
    {
        return collectables[type];
    }

    private void CreateUI()
    {
        int counter = 0;
        foreach (CollectableType type in Enum.GetValues(typeof(CollectableType)))
        {
            GameObject obj = Instantiate(collectionDisplay.gameObject, transform);
            RectTransform rectTransform = obj.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector3(0, -100 + (counter * rectTransform.rect.height * -1), 0);
            displays[type] = obj.GetComponent<CollectableDisplay>();
            counter++;
        }
    }
}
