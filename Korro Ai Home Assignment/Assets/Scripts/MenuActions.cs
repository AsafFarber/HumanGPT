using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    public void LoadGameScene(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }

        SceneManager.LoadScene(1);
    }

    public void LoadCurrentScene(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }

        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }

        Application.Quit();
    }
}
