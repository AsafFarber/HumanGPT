using UnityEngine;
using Zenject;
using Cinemachine;

public class RotateToCursor : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [Inject]
    private CinemachineVirtualCamera virtualCamera;
    [Inject]
    private Camera mainCamera;
    private Quaternion targetRotation;

    void Update()
    {
        if (Time.deltaTime == 0)
            return;
        CalculateTargetRotation();
        transform.rotation = targetRotation;
    }
    private void OnEnable()
    {
        virtualCamera.LookAt = transform;
    }
    void CalculateTargetRotation()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Ray ray = mainCamera.ScreenPointToRay(mouseScreenPosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, layerMask))
        {
            Vector3 targetPosition = hitInfo.point;
            Vector3 direction = targetPosition - transform.position;
            direction.y = 0;
            targetRotation = Quaternion.LookRotation(direction);
        }

    }
}
