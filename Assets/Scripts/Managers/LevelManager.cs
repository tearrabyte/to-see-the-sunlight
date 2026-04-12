using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Variables
    [SerializeField] private List<Level> levels;
    private Level currentLevel;

    // Events
    public Action onLevelStart;
    public Action onLevelEnd;

    // Methods
    public Level GetCurrentLevel()
    {
        return currentLevel;
    }

    public void LoadLevel(Level level)
    {

    }

    public void UnloadLevel()
    {

    }

    public void RestartLevel()
    {

    }
}
