using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] float currentSpeed = 1;
    [SerializeField] private int health = 100;
    GameObject currentTarget;

    void Update()
    {
        Move();
        UpdateTheAnimationState();
    }

    private void UpdateTheAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAtacking", false);
        }
    }

    void Move()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAtacking", true);
        currentTarget = target;
    }

    public void StikeCurrentTarget(float damage)
    {
        if (!currentTarget)
        {
            return;
        }

        Defender health = currentTarget.GetComponent<Defender>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        }

        ProcessHit(damageDealer);
    }

    void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamageDealer();

        damageDealer.DestroyDamageDealer();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}