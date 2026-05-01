using UnityEngine;

/*
 * MainMenu
 * --------
 * Represents the main menu UI.
 * Provides options to start the game, access settings, or quit.
 */

public class MainMenu : Menu
{
    //game manager is a core, buttons and options panel are swapped depending on what is open now 
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject Buttons;
    [SerializeField] private GameObject OptionsPanel;
    // Methods
    /*START
     Ensures the menu begins in the correct default state,
     with buttons visible and options panel hidden
    */
    private void Start()
    {
        if (OptionsPanel != null) OptionsPanel.SetActive(false);
        if (Buttons != null) Buttons.SetActive(true);
    }
    /*OPEN
     Overrides base Open() to reset panel state on every open,
     preventing options panel from staying between sessions
    */
    public override void Open()
    {
        base.Open();
        if (Buttons != null) Buttons.SetActive(true);
        if (OptionsPanel != null) OptionsPanel.SetActive(false);
    }
    //begins the game 
    public void StartGame()
    {
        gameManager.StartGame();
    }
    /*OPEN SETTINGS
     Swaps the main buttons out for the options panel
    */
    public void OpenSettings()
    {
        Buttons.SetActive(false);
        OptionsPanel.SetActive(true);
    }
    /*CLOSE SETTINGS
     Returns from the options panel back
    */
    public void CloseSettings()
    {
        Buttons.SetActive(true);
        OptionsPanel.SetActive(false);
    }
    //quits the game 
    public void QuitGame()
    {
        Application.Quit();
    }

}
