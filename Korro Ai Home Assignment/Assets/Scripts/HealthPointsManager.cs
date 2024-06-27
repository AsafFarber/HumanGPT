using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
public class HealthPointsManager : MonoBehaviour
{
    [Inject]
    private IterationManager iterationManager;

    [SerializeField] private GameObject healthPointUiImage;
    [SerializeField] private int initialAmount = 3;
    [SerializeField] private UnityEvent onHpEqualZerp;

    private int amount;
    public int GetCurrentAmount => amount;
    void Start()
    {
        amount = initialAmount;
        for (int i = 0; i < amount; i++)
            Instantiate(healthPointUiImage, transform);

        iterationManager.OnIterationInitialize += ReduceOne;
    }
    void OnDestroy()
    {
        iterationManager.OnIterationInitialize -= ReduceOne;
    }
    public void ReduceOne()
    {
        amount--;
        Destroy(transform.GetChild(transform.childCount - 1).gameObject);
        if (amount <= 0)
            onHpEqualZerp?.Invoke();
    }
}
