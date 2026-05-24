using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MainMenuTests
{
    /*
     * TEST - OPEN SETTINGS
     * Verifies that calling OpenSettings() hides the buttons
     * and makes the options panel visible.
     */
    [Test]
    public void OpenSettings_ShowsOptionsPanel()
    {
        //arrange
        var menuGO = new GameObject();
        var mainMenu = menuGO.AddComponent<MainMenu>();

        var buttons = new GameObject();
        var optionsPanel = new GameObject();

        var buttonsField = typeof(MainMenu).GetField("Buttons",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var optionsPanelField = typeof(MainMenu).GetField("OptionsPanel",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        buttonsField.SetValue(mainMenu, buttons);
        optionsPanelField.SetValue(mainMenu, optionsPanel);

        buttons.SetActive(true);
        optionsPanel.SetActive(false);

        //act
        mainMenu.OpenSettings();

        //assert
        Assert.IsTrue(optionsPanel.activeSelf);
    }
}
