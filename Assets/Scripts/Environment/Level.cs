using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Variables
    [SerializeField] private List<Hazard> hazards;
    [SerializeField] private BiomeMechanic biomeMechanic;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private PlayerPrefs player;
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
