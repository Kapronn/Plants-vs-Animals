using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damageDealer = 100;

    public int GetDamageDealer()
    {
        return damageDealer; 
    }

    public void DestroyDamageDealer()
    {
        Destroy(gameObject);
    }
    
}
