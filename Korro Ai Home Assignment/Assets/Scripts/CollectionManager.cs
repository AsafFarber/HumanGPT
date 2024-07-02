using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CollectionManager : MonoBehaviour
{
    [SerializeField]
    private CollectableDisplay collectionDisplay;

    [SerializeField]
    private AudioSource audioSource;

    [Inject]
    private IterationManager iterationManager;

    private readonly Dictionary<CollectableType, int> collectablesAmount = new Dictionary<CollectableType, int>();
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
        CollectableData collectableData = collectable.GetcollectableData();
        // Increase collectable's type amount.
        // Display collectable's image in the UI.
        // Spawn collectable's visual effect.
        // Play collectable's audio.
        collectablesAmount[collectableData.type]++;
        displays[collectableData.type].AddCollectableGraphic(collectableData.image);
        Instantiate(collectableData.visualEffect.gameObject, collectable.transform.position, Quaternion.identity);
        audioSource.PlayOneShot(collectableData.soundEffect);
    }

    public void ResetCollection()
    {
        collectablesAmount.Clear();
        foreach (CollectableType type in Enum.GetValues(typeof(CollectableType)))
        {
            collectablesAmount[type] = 0;
            displays[type].ResetCollectableDisplay();
        }
    }

    public int GetCollectableAmount(CollectableType type)
    {
        return collectablesAmount[type];
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
