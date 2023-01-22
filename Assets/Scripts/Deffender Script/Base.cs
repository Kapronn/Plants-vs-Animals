using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        GameObject Object = enemy.gameObject;
        if (Object.GetComponent<Attacker>())
        {
            FindObjectOfType<HealthDisplay>().SpendingHealth(damage);
            Destroy(enemy.gameObject);
        }
        else
        {
            Destroy(enemy.gameObject);
        }
    }
}