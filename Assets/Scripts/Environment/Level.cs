using System.Collections.Generic;
using UnityEngine;

/*
 * Level
 * -----
 * Represents a single playable level.
 * Contains level-specific data such as layout, hazards, and biome configuration.
 * Used by LevelManager to load and manage gameplay environments.
 */

public class Level : MonoBehaviour
{
    // Variables
    [SerializeField] private List<Hazard> hazards;
    [SerializeField] private BiomeMechanic biomeMechanic;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private Player player;
    [SerializeField] private Transform spawnPoint;

    private LevelManager levelManager;

    // Methods
    public void StartLevel()
    {

    }

    public void EndLevel()
    {

    }

    public void ResetLevel()
    {

    }

    public void UpdateLevel()
    {

    }
}
