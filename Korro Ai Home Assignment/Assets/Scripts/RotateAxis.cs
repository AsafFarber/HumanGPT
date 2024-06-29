using UnityEngine;

public class RotateAxis : MonoBehaviour
{
    [SerializeField]
    private float xRotation;

    [SerializeField]
    private float yRotation;

    [SerializeField]
    private float zRotation;

    private void Update()
    {
        transform.Rotate(xRotation * Time.deltaTime, yRotation * Time.deltaTime, zRotation * Time.deltaTime);
    }
}
