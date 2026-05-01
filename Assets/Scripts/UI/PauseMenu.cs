using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

/*
 * PAUSE MENU
 * Handles pausing and resuming the game, listens for the escape
 * key to toggle the pause state during an active run
*/

public class PauseMenu : Menu
{
    //pause menu panel
    public GameObject Container;
    //escape key detection
    private PlayerInputActions inputActions;

    /*
     START
     Ensures the pause menu is hidden when the scene loads
    */
    private void Start()
    {
        Container.SetActive(false);
    }

    /*
     AWAKE
     Creates the input actions instance before anything else runs
    */
    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }
    /*
     ON ENABLE/ON DISABLE
     Handles input actions, prevents ghost calls
     
     */
    private void OnEnable()
    {
        inputActions.UI.Enable();
        inputActions.UI.Pause.performed += OnPausePressed;
    }

    private void OnDisable()
    {
        inputActions.UI.Pause.performed -= OnPausePressed;
        inputActions.UI.Disable();
    }
    /*
     ON PAUSE PRESSED
     Works on escape, resumes if already paused, otherwise freezes time and shows the pause menu
     */
    private void OnPausePressed(InputAction.CallbackContext ctx)
    {
        if (Container.activeSelf) ResumeButton();
        else
        {
            Container.SetActive(true);
            Time.timeScale = 0;
        }
    }
    /*
     RESUME BUTTON
     hides pause menu and restores the time
     */
    public void ResumeButton()
    {
        Container.SetActive(false);
        Time.timeScale = 1;
    }
    /*
     QUIT TO MENU BUTTON
     Restores time, disables this object, and loads the main menu scene
     */
    public void QuittoMenu()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        SceneManager.LoadScene("UI_MainMenu");
    }
    /*
     RESTART BUTTON
     Restores time and reloads the current scene from the beginning
     */
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
