using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;
using UnityEngine.Events;
public class CollectionManager : MonoBehaviour
{
    [SerializeField] private CollectableDisplay collectionDisplay;
    [SerializeField] private CollectableItem[] collectableItems;
    [SerializeField] private AudioSource audioSource;

    [Inject]
    private IterationManager iterationManager;

    private Dictionary<CollectableType, int> collectables = new Dictionary<CollectableType, int>();
    private Dictionary<CollectableType, CollectableDisplay> displays = new Dictionary<CollectableType, CollectableDisplay>();

    void Start()
    {
        CreateUI();
        ResetCollection();
        iterationManager.OnIterationInitialize += ResetCollection;
    }
    void OnDestroy()
    {
        iterationManager.OnIterationInitialize -= ResetCollection;
    }
    public void AddCollectable(CollectableType type)
    {
        collectables[type]++;
        foreach(CollectableItem collectableItem in collectableItems)
        {
            if(collectableItem.type == type)
            {
                displays[type].AddCollectableGraphic(collectableItem.image);
                audioSource.PlayOneShot(collectableItem.soundEffect);
            }
        }
    }
    public void ResetCollection()
    {
        collectables = new Dictionary<CollectableType, int>();
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
