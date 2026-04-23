using UnityEngine;

/*
 * UIManager
 * ---------
 * Manages UI state and transitions between menus and HUD elements.
 * Responsible for showing, hiding, and switching UI screens.
 */

public class UIManager : MonoBehaviour
{
    // Variables
    public Menu currentMenu;

    public MainMenu mainMenu;
    public SettingsMenu settingsMenu;
    public PauseMenu pauseMenu;
    public DeathScreen deathScreen;
    public CardSelectionMenu cardSelectionMenu;

    public GameObject hud;

    // Methods:

    // Specifically, it demonstrates a menu without logic for the previous one.
    public void ShowMenu(Menu menu)
    {
        if (menu != null) menu.Open();
    }

    // This option hides the currently active menu.
    public void HideMenu()
    {
        if (currentMenu != null) currentMenu.Close();
    }

    // This closes the current menu, and then it opens a new one (e.g., Main Menu to Settings).
    public void SwitchMenu(Menu menu)
    {
        if (currentMenu != null)
        {
            currentMenu.Close();
        }

        currentMenu = menu;
        currentMenu.Open();
    }

    // This section activates the Player HUD (Heads-Up Display) automatically and closes any open menus.
    public void ShowHUD()
    {
        HideMenu();
        if (hud != null) hud.SetActive(true);
    }
}
