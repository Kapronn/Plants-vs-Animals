using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Update = UnityEngine.PlayerLoop.Update;

public class OptionsContoller : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private float _defaultVolume = 0.5f;

    void Start()
    {
        
        _volumeSlider.value = PlayerPrefsController.GetMasterVolume();
    }

    private void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayerScript>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(_volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No Music Player found! ");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(_volumeSlider.value);
        SceneManager.LoadScene("StartScene");
    }

    public void SetDefaults()
    {
        _volumeSlider.value = _defaultVolume;
    }
}