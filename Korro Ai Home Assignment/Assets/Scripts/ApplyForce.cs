using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    [SerializeField]
    private Vector3 magnitude;

    public void ApplyToObject(GameObject obj)
    {
        if (obj == null)
        {
            return;
        }

        Rigidbody objectRigidbody = obj.GetComponent<Rigidbody>();
        if (objectRigidbody == null)
        {
            return;
        }

        Vector3 direction = obj.transform.position - transform.position;
        direction.Normalize();
        objectRigidbody.AddForce(Vector3.Scale(direction, magnitude), ForceMode.Impulse);

        PlayerAnimation playerAnimation = obj.GetComponent<PlayerAnimation>();
        if (playerAnimation != null)
        {
            playerAnimation.HitAnimation();
        }
    }
}
