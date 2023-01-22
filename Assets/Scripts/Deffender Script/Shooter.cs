using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject gun;
    

    public void Fire() //Used in Event.
    {
        Instantiate(projectile, gun.transform.position, Quaternion.identity);
        
    }

    

    
}