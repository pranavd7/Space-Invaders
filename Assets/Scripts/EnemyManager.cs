using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Enemy[] enemies;

    public Action OnEnemyDeath;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Enemy enemy in enemies)
        {
            Health health = enemy.GetComponent<Health>();
            health.OnDeathEvent += () => OnEnemyDeath?.Invoke();
        }
    }
}
