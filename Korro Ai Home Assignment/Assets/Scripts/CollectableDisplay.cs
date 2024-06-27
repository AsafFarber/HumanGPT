using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableDisplay : MonoBehaviour
{
    [SerializeField] private GameObject collectablTemplate;
    public void AddCollectableGraphic(Sprite collectableImage)
    {
        GameObject obj = Instantiate(collectablTemplate, transform);
        obj.GetComponent<Image>().sprite = collectableImage;
    }
    public void ResetCollectableDisplay()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
