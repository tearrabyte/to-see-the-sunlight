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
    //singleton, can access without a reference, get is public to read, set is private to assign
    public static UIManager Instance { get; private set; }

    //different menus
    public Menu currentMenu;
    public MainMenu mainMenu;
    public SettingsMenu settingsMenu;
    public PauseMenu pauseMenu;
    public DeathScreen deathScreen;
    public CardSelectionMenu cardSelectionMenu;

    //placeholder for now 
    public GameObject hud;


    //destroy any duplicate UIManager instances if happens
    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    // Methods:

    /*
     SHOW MENU
     Closes the current menu if one is open, then opens the requested menu
     */
    public void ShowMenu(Menu menu)
    {
        if (currentMenu != null) currentMenu.Close();
        currentMenu = menu;
        currentMenu.Open();
    }

    /*
     HIDE MENU
     Closes the current menu and clears the active menu reference
     */
    public void HideMenu()
    {
        if (currentMenu != null) currentMenu.Close();
        currentMenu = null;
    }

    /*
     SWITCH MENU
     Transitions from the current menu to a new one, closing the old one first
     */
    public void SwitchMenu(Menu menu)
    {
        HideMenu();
        ShowMenu(menu);
    }

    /*
     SHOW HUD
     Closes any open menu and activates the gameplay HUD
     */
    public void ShowHUD()
    {
        HideMenu();
        if (hud != null) hud.SetActive(true);
    }
}
