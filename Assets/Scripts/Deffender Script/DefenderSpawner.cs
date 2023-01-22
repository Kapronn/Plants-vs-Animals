using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class DefenderSpawner : MonoBehaviour
{
    private Defender _defender;
    private void OnMouseDown()
    {
        if (!_defender) {return;}
        AttemptToPlaceDefenderAt();
    }

    public void SetDefenderPrefab(Defender defenderPrefab)
    {
         _defender = defenderPrefab;
    }

    void AttemptToPlaceDefenderAt()
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = _defender.GetStarCost();
        if (starDisplay.HaveEnoughtStars(defenderCost))
        {
            SpawnNewDefender();
            starDisplay.SpendingStars(defenderCost);
        }
        
    }
   private Vector2 GetSquareClicked()
   {
       Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
       Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
       Vector2 gridPos = SnapToGrid(worldPosition);
       return gridPos;
   }

   Vector2 SnapToGrid(Vector2 rawPosition)
   {
       float newX = Mathf.RoundToInt(rawPosition.x);
       float newY = Mathf.RoundToInt(rawPosition.y);
       return new Vector2(newX, newY);
   }
    private void SpawnNewDefender()
    { 
        if (!_defender) {return;}
        Instantiate(_defender, GetSquareClicked(), Quaternion.identity);
        
    }
}
