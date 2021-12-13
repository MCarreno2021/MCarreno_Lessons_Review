using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public const float defaultVolume = .5f;
    public const string volumeLevelKey = "VolumeLevel";
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        float volume = PlayerPrefs.GetFloat(volumeLevelKey, defaultVolume);
        audioSource.volume = volume;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdjustVolume(float level)
    {
        audioSource.volume = level;
        PlayerPrefs.SetFloat("VolumeLevel", level);
    }
}
