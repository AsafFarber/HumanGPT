using TMPro;
using UnityEngine;
using Zenject;

public class ResultPopup : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI header;

    [SerializeField]
    private TextMeshProUGUI subHeader;

    [Inject]
    private CollectionManager collectionManager;

    public void ShowWinPopup()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        header.text = "Experiment Succeeded!";
        subHeader.text = "The Last Robot Arrived With " + collectionManager.GetCollectableAmount(CollectableType.Coin) + " Coins.";
    }

    public void ShowLosePopup()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        header.text = "Experiment Failed.";
        subHeader.text = "All Robots Destroyed.";
    }
}
