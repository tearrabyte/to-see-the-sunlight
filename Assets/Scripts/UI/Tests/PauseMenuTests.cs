using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PauseMenuTests
{
    /*
     TEST - RESUME BUTTON HIDES CONTAINER
     Verifies that calling ResumeButton() hides the pause menu container and restores time to normal
     */
    [Test]
    public void ResumeButton_HidesContainerAndRestoresTime()
    {
        //arrange
        var menuGO = new GameObject();
        var pauseMenu = menuGO.AddComponent<PauseMenu>();
        var container = new GameObject();
        pauseMenu.Container = container;
        container.SetActive(true);
        Time.timeScale = 0;

        //act
        pauseMenu.ResumeButton();

        //assert
        Assert.IsFalse(container.activeSelf);
        Assert.AreEqual(1, Time.timeScale);
    }
}
