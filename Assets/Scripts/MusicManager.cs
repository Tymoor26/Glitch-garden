using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
    public AudioClip[] LevelMusicChangeArray;
    private AudioClip currentlyPlaying;
    private AudioSource audioSource;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnLevelWasLoaded(int level)
    {
        AudioClip clip = LevelMusicChangeArray[level];
        if (clip && !(clip == currentlyPlaying))
        {
            audioSource.clip = clip;
            audioSource.loop = true;
            audioSource.Play();
            currentlyPlaying = clip;
        }
        
    }

    public void changeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
