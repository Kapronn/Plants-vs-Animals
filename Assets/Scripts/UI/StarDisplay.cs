using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] private int currentStars = 100;
    private Text starText;

    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starText.text = currentStars.ToString();
    }

    public bool HaveEnoughtStars(int amount)
    {
        return currentStars >= amount;
    }
    public void AddStars(int amount)
    {
        currentStars += amount;
        UpdateDisplay();
    }

    public void SpendingStars(int amount)
    {
        if (currentStars >= amount)
        {
            currentStars -= amount;
            UpdateDisplay();
        }
    }
}