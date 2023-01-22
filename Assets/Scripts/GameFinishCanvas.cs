using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinishCanvas : MonoBehaviour
{
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject loseCanvas;
    

    private void Start()
    {
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
    }

    public void WinLabelOn()
    {
        winCanvas.SetActive(true);
    }

    public void LoseLabelOn()
    {
        loseCanvas.SetActive(true);
        
    }
}
