using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private UIManager uiManager;

    private bool isRunActive;

    // Events
    public event Action onRunStart;
    public event Action onRunEnd;
    public event Action onGamePause;
    public event Action onGameResume;

    // Methods
    public void StartGame()
    {
        isRunActive = true;
        onRunStart?.Invoke();
    }

    public void RestartRun()
    {
        isRunActive = true;
        levelManager.RestartLevel();
        onRunStart?.Invoke();
    }

    public void EndRun()
    {
        isRunActive = false;
        onRunEnd?.Invoke();
    }

    public void PauseGame()
    {
        onGamePause?.Invoke();
    }

    public void ResumeGame()
    {
        onGameResume?.Invoke();
    }
}
