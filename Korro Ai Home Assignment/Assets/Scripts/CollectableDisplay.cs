using UnityEngine;
using UnityEngine.UI;

public class CollectableDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject collectableTemplate;

    public void AddCollectableGraphic(Sprite collectableImage)
    {
        if (collectableTemplate == null)
        {
            Debug.LogError("AddCollectableGraphic: No template assigned.");
            return;
        }

        if (collectableImage == null)
        {
            Debug.LogError("AddCollectableGraphic: No sprite assigned.");
            return;
        }

        GameObject obj = Instantiate(collectableTemplate, transform);
        Image image = obj.GetComponent<Image>();
        if (image != null)
        {
            image.sprite = collectableImage;
        }
        else
        {
            Debug.LogError("AddCollectableGraphic: No Image component found on the template.");
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
