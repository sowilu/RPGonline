using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 30;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            //TODO: death animation
            //TODO: loot
            Destroy(gameObject);
        }
    }

    public bool IsDead()
    {
        return health <= 0;
    }
}
