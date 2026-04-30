using System;
using UnityEngine;

/*
 * GameManager
 * -----------
 * Controls overall game flow, and manages core game events.
 * Includes starting, pausing, restarting and ending runs.
 * Acts as a central coordinator between core systems including LevelManager, AudioManager, and UIManager. 
 */

public class GameManager : MonoBehaviour
{
    // Variables
    //game manager coordinates these core systems
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private UIManager uiManager;

    //ensure game state is not lost when switching scenes
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    //flag for tracking state
    private bool isRunActive;

    // Events
    public event Action onRunStart;
    public event Action onRunEnd;
    public event Action onGamePause;
    public event Action onGameResume;

    // Methods
    /*
     START GAME
     Marks a run as active and starts event
     */
    public void StartGame()
    {
        isRunActive = true;
        onRunStart?.Invoke();
    }
    //placeholder for the future restart for now
    public void RestartRun()
    {
        isRunActive = true;
        levelManager.RestartLevel();
        onRunStart?.Invoke();
    }
    /*
     END RUN
     Marks the run as inactive and runs end event.
     */
    public void EndRun()
    {
        isRunActive = false;
        onRunEnd?.Invoke();
    }
    //placeholder for the future pause for now 
    public void PauseGame()
    {
        onGamePause?.Invoke();
    }
    //placeholder for the future resume for now 
    public void ResumeGame()
    {
        onGameResume?.Invoke();
    }
}
