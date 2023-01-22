using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        
        GameObject otherGameObject = otherCollider.gameObject;
        if (otherGameObject.GetComponent<GraveStone>())
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }
        else if (otherGameObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherGameObject);
        }
    }
}
