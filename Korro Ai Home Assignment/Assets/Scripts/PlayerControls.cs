using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
public class PlayerControls : MonoBehaviour
{
    private float direction = 0;
    [SerializeField] private PlayerMovment playerMovment;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerAnimation playerAnimation;

    void FixedUpdate()
    {
        playerMovment.MovePlayer(direction);
        playerAnimation.MoveAnimation(direction);
    }
    public void ForwardButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            direction = 1;
        }
        if (context.canceled)
        {
            direction = 0;
        }
    }
    public void BackwardButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            direction = -1;
        }
        if (context.canceled)
        {
            direction = 0;
        }
    }
    public void JumpButton(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        playerMovment.Jump();
    }
}
