using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeffenderButtonScript : MonoBehaviour
{
    [SerializeField] private Defender _defenderPrefab;
    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DeffenderButtonScript>();
        foreach (DeffenderButtonScript button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(65, 65, 65, 255);
        }
        
        FindObjectOfType<DefenderSpawner>().SetDefenderPrefab(_defenderPrefab);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}