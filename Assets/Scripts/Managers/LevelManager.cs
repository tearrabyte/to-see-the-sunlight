using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * LevelManager
 * ------------
 * Manages level lifecycle including loading, unloading, and restarting levels.
 * Tracks the current active level and handles transitions between levels.
 */

public class LevelManager : MonoBehaviour
{
    // Variables
    [SerializeField] private List<Level> levels;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private string levelSceneName = "Level_GlowwormCave";
    private Level currentLevel;

    // Events
    public Action onLevelStart;
    public Action onLevelEnd;

    //loads and unloads levels automatically when the game starts and ends
    private void Awake()
    {
        gameManager.onRunStart += StartLevel;
        gameManager.onRunEnd += UnloadLevel;
    }
    // Methods
    /*
    START LEVEL
    Loads the first level if one exists, otherwise falls back to loading the level by scene name
    */
    private void StartLevel()
    {
        if (levels != null && levels.Count > 0)
            LoadLevel(levels[0]);           
        else
            SceneManager.LoadScene(levelSceneName); 
    }
    /*
     GET CURRENT LEVEL
     Returns the currently active level instance
     */
    public Level GetCurrentLevel()
    {
        return currentLevel;
    }
    /*
     LOAD LEVEL
     Unloads any existing level, then instantiates the new one and starts event
     */
    public void LoadLevel(Level level)
    {
        if (currentLevel != null) UnloadLevel();
        currentLevel = Instantiate(level);
        onLevelStart?.Invoke();
    }
    /*
     UNLOAD LEVEL
     Destroys the current level istarts the end event, does nothing if no level is loaded
     */
    public void UnloadLevel()
    {
        if (currentLevel == null) return;
        Destroy(currentLevel.gameObject);
        currentLevel = null;
        onLevelEnd?.Invoke();
    }
    //placeholder for the future restart for now
    public void RestartLevel()
    {

    }
}
