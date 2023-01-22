using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private int currentHealth = 500;
    [SerializeField] private AudioClip theEnd;
    private Text healthText;

    private void Start()
    {
        healthText = GetComponent<Text>();
        UpdateHealthDisplay();
        Time.timeScale = 1f;
    }
    void UpdateHealthDisplay()
    {
        healthText.text = currentHealth.ToString();
    }

    public void SpendingHealth(int damage)
    {
        currentHealth -= damage;
        UpdateHealthDisplay();
        
        if (currentHealth <= 0)
        {
            GameOver();
        }
        
    }

    private void GameOver()
    {
        FindObjectOfType<MenuMusicScript>().StopMusic();
        AudioSource.PlayClipAtPoint(theEnd, Camera.main.transform.position);
        FindObjectOfType<GameFinishCanvas>().LoseLabelOn();
        Time.timeScale = 0f;
    }

    
}