using TMPro;
using UnityEngine;
using Zenject;

public class ResultPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI header;
    [SerializeField] private TextMeshProUGUI subHeader;

    [Inject]
    private CollectionManager collectionManager;

    public void ShowWinPopup()
    {
        Collectable[] collectables = FindObjectsOfType<Collectable>(true);
        int maximumCoinsAmount = 0;
        foreach(Collectable collectable in collectables)
        {
            if (collectable.GetCollectableType() == CollectableType.Coin)
                maximumCoinsAmount++;
        }
        Time.timeScale = 0;
        gameObject.SetActive(true);
        header.text = "Experiment Succeed!";
        subHeader.text = "The Last Robot Arrived With " + collectionManager.GetCollectableAmount(CollectableType.Coin) + " Coins, Out Of " + maximumCoinsAmount+ ".";
    }
    public void ShowLosePopup()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        header.text = "Experiment Failed.";
        subHeader.text = "All Robots Destroyed.";
    }
}
