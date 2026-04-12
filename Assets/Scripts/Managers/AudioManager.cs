using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Variables
    [SerializeField] private float musicVolume = 1f;
    [SerializeField] private float sfxVolume = 1f;
    private bool isMuted;

    private AudioClip currentTrack;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    // Methods

    public void PlaySound(AudioClip clip)
    {

    }

    public void StopSound(AudioClip clip)
    {

    }

    public void PlayMusic(AudioClip track)
    {

    }

    public void StopMusic()
    {

    }
}
