using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    private float direction = 0;

    [SerializeField]
    private PlayerMovment playerMovment;

    [SerializeField]
    private PlayerAnimation playerAnimation;

    private void FixedUpdate()
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
        else if (context.canceled)
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
        else if (context.canceled)
        {
            direction = 0;
        }
    }

    public void JumpButton(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }

        playerMovment.Jump();
    }
}
