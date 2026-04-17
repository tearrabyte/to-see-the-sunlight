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

    public HUD hud;

    // Methods
    public void ShowMenu(Menu menu)
    {

    }

    public void HideMenu()
    {

    }

    public void SwitchMenu(Menu menu)
    {
        
    }

    public void ShowHUD()
    {

    }
}
