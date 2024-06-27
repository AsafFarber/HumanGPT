using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    [SerializeField] private Vector3 magnitude;

    public void ApplyToObject(GameObject obj)
    {
        Rigidbody objectRigidbody = obj.GetComponent<Rigidbody>();
        if (objectRigidbody == null)
        {
            return;
        }

        Vector3 direction = obj.transform.position - transform.position;
        direction.Normalize();
        objectRigidbody.AddForce(Vector3.Scale(direction, magnitude), ForceMode.Impulse);

        PlayerAnimation playerAnimation = obj.GetComponent<PlayerAnimation>();
        if (objectRigidbody != null)
            playerAnimation.HitAnimation();
    }
}
