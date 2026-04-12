using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Variables
    public float currentTime;
    public bool isRunning;
    public bool isPaused;

    // Events
    public Action onTimerUpdated;

    // Unity Method
    public void Update()
    {

    }

    // Methods
    public void StartTimer()
    {
        isRunning = true;
        isPaused = false;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void PauseTimer()
    {
        if(!isRunning)
        {
            return;
        }

        isPaused = true;
    }

    public void ResetTimer()
    {
        currentTime = 0f;
        isRunning = false;
        isPaused = false;

        onTimerUpdated?.Invoke();
    }


}
