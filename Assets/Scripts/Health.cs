using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] ParticleSystem deathExplosion;

    float currentHealth;

    public Action OnDeathEvent;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        if (animator) animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void IncreaseHealth(float gain)
    {
        currentHealth = Mathf.Min(currentHealth + gain, maxHealth);
    }

    void Die()
    {
        if (animator) animator.SetTrigger("Death");

        if (deathExplosion)
        {
            Instantiate(deathExplosion, transform.position, Quaternion.identity);
        }

        OnDeathEvent?.Invoke();

        Destroy(gameObject);
    }
}
