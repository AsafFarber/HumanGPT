using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAxis : MonoBehaviour
{
    [SerializeField] private float xRotation, yRotation, zRotation;
    void Update()
    {
        transform.Rotate(xRotation * Time.deltaTime, yRotation * Time.deltaTime, zRotation * Time.deltaTime);
    }
}
