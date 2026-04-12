using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public Transform healthBar;
    public int maxHealth = 30;
    
    private int health;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        health = maxHealth;
        StartCoroutine(WalkAround());
    }

    IEnumerator WalkAround()
    {
        while (true)
        {
            var target = new Vector3();
            target.x = Random.Range(10, 90);
            target.y = 500;
            target.z = Random.Range(10, 90);

            if (Physics.Raycast(target, Vector3.down, out RaycastHit hit))
            {
                agent.destination = hit.point;
            }
            
            yield return new WaitForSeconds(Random.Range(10, 20));
        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;
            //TODO: death animation
            //TODO: loot
            Destroy(gameObject);
        }
        
        healthBar.localScale = new Vector3((float)health / maxHealth, 1, 1);
    }

    public bool IsDead()
    {
        return health <= 0;
    }
}
