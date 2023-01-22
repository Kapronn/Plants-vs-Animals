using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Zucchini : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] float rotateSpeed = -2;

    private void Update()
    {
        Move();
    }

    void Move()
    {
        var xMove = transform.position.x + moveSpeed * Time.deltaTime;
        transform.position = new Vector3(xMove, transform.position.y);
        transform.Rotate(0, 0, rotateSpeed);
    }
    
}