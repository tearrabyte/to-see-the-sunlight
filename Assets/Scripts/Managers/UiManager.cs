using UnityEngine;

/*
 * UI MANAGER
 * Central manager for all UI state. Handles transitioning between
 * menus and activating the HUD during gameplay.
 */
public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public Menu currentMenu;
    public MainMenu mainMenu;
    public SettingsMenu settingsMenu;
    public PauseMenu pauseMenu;
    public DeathScreen deathScreen;
    public CardSelectionMenu cardSelectionMenu;

    public GameObject hud;

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ShowMenu(Menu menu)
    {
        if (currentMenu != null) currentMenu.Close();
        currentMenu = menu;
        currentMenu.Open();
    }

    public void HideMenu()
    {
        if (currentMenu != null) currentMenu.Close();
        currentMenu = null;
    }

    public void SwitchMenu(Menu menu)
    {
        HideMenu();
        ShowMenu(menu);
    }

    public void ShowHUD()
    {
        HideMenu();
        if (hud != null) hud.SetActive(true);
    }
}