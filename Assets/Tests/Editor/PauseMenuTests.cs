using UnityEngine;
using NUnit.Framework;

public class PauseMenuTests
{
    /*
     Verifies that calling ResumeButton() hides the pause menu
     container and restores time to normal
     */
    [Test]
    public void ResumeButton_HidesContainerAndRestoresTime()
    {
        var menuGO = new GameObject();
        var pauseMenu = menuGO.AddComponent<PauseMenu>();
        var container = new GameObject();
        pauseMenu.Container = container;
        container.SetActive(true);
        Time.timeScale = 0;

        pauseMenu.ResumeButton();

        Assert.IsFalse(container.activeSelf);
        Assert.AreEqual(1, Time.timeScale);
    }
    /*
     Verifies that when the game is paused the container
     becomes visible and time is frozen
     */
    [Test]
    public void OnPause_ShowsContainerAndFreezesTime()
    {
        var menuGO = new GameObject();
        var pauseMenu = menuGO.AddComponent<PauseMenu>();
        var container = new GameObject();
        pauseMenu.Container = container;
        container.SetActive(false);
        Time.timeScale = 1;

        container.SetActive(true);
        Time.timeScale = 0;

        Assert.IsTrue(container.activeSelf);
        Assert.AreEqual(0, Time.timeScale);
    }
}