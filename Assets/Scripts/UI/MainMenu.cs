using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * MainMenu
 * --------
 * Represents the main menu UI.
 * Provides options to start the game, access settings, or quit.
 */

// The logic for the Main Menu buttons includes loading the level and quitting the game.

public class MainMenu : Menu
{
    // Methods:

    // Loads the tutorial scene (Glowworm Cave).
    public void StartGame()
    {
        // TODO: Call GameManager
        SceneManager.LoadScene("GlowwormCave");
    }

    // Placeholder for the Options menu logic to be implemented in Sprint 2.

    // Planned for future implementation; currently acts as a placeholder.
    public void OpenSettings()
    {
        // UIManager.Instance.ShowMenu("Options");
        Debug.Log("Options menu requested.");

        // UIManager.Instance.SwitchMenu(UIManager.Instance.settingsMenu);
    }

    // Closes the application.
    // Closes the application successfully.
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game has exited.");
    }
}
