using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    Enemy[] enemies;

    int numEnemies;

    public Action OnEnemyDeath;
    public Action OnAllEnemiesDead;

    // Start is called before the first frame update
    void Start()
    {
        enemies = FindObjectsOfType<Enemy>();
        numEnemies = enemies.Length;
        foreach (Enemy enemy in enemies)
        {
            Health health = enemy.GetComponent<Health>();
            health.OnDeathEvent += RefreshNumEnemies;
        }
    }

    /// <summary>
    /// Keep count of enemies alive
    /// </summary>
    void RefreshNumEnemies()
    {
        OnEnemyDeath?.Invoke();

        numEnemies--;
        if (numEnemies <= 0)
            OnAllEnemiesDead?.Invoke();
    }
}
