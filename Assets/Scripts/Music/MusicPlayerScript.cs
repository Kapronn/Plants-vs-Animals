using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerScript : MonoBehaviour
{
    private AudioSource _audioSource;
    void Start()
    {
        
        _audioSource=GetComponent<AudioSource>();
        _audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    public void SetVolume(float volume)
    {
        _audioSource.volume = volume;
    }
}
