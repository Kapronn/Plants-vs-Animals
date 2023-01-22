using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using Update = UnityEngine.PlayerLoop.Update;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] Attacker[] attacker;
    [SerializeField] bool spawn = true;
    [SerializeField] float minTimeSpawn = 1f;
    [SerializeField] float maxTimeSpawn = 5f;
   

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
        
    }
    IEnumerator SpawnCoroutine()
    {
        while (spawn)
        {

            yield return new WaitForSeconds(Random.Range(minTimeSpawn, maxTimeSpawn));
            SpawnAttacher();
        }

    }
    void SpawnAttacher()
    {
        var attackerIndex = Random.Range(0, attacker.Length);
        Spawn(attacker[attackerIndex]);
    }

    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, Quaternion.identity);
        newAttacker.transform.parent = transform;
    }

    
}
