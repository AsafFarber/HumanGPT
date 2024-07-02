using UnityEngine;
using UnityEngine.UI;

public class CollectableDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject collectableTemplate;

    public void AddCollectableGraphic(Sprite collectableImage)
    {
        GameObject obj = Instantiate(collectableTemplate, transform);
        Image image = obj.GetComponent<Image>();
        if (image != null)
        {
            image.sprite = collectableImage;
        }
    }

    public void ResetCollectableDisplay()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
