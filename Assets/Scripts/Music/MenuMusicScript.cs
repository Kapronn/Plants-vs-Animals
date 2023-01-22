using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicScript : MonoBehaviour
{
    private AudioSource _audioSource;

    public void StopMusic()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Stop();
    }
}
