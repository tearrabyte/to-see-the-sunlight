using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * DeathScreen
 * -----------
 * Displays when the player dies.
 * Provides options to restart the run or return to the main menu.
 */

public class DeathScreen : Menu
{
    // Methods
    public void RestartRun()
    {

    }

    /*
     * RETURN TO MAIN MENU
     * Loads the main menu scene when the button is pressed.
     */
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("UI_MainMenu");
    }
}
