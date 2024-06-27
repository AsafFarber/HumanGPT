using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpMagnitude;
    [SerializeField] private float jumpForwardMomentum;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private PlayerAnimation playerAnimation;
    private float direction;
    public void MovePlayer(float playerDirection)
    {
        direction = playerDirection;
        Vector3 moveDirection = transform.forward * direction;
        Vector3 movement = movementSpeed * Time.deltaTime * moveDirection;

        rigidBody.MovePosition(transform.position + movement);
    }
    public void Jump()
    {
        if (!IsGrounded()) return;

        Vector3 jumpForce = new Vector3(0, jumpMagnitude, 0);
        Vector3 forwardForce = direction * jumpForwardMomentum * transform.forward;

        rigidBody.AddForce(jumpForce, ForceMode.Impulse);
        rigidBody.AddForce(forwardForce, ForceMode.Impulse);

        playerAnimation.Jump();
    }
    private bool IsGrounded()
    {
        if (rigidBody.velocity.y > 00000.1f)
            return false;

        if (rigidBody.velocity.y < -00000.1f)
            return false;

        return true;
    }
}
