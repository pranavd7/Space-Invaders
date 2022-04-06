using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int maxHealth = 100;
    [SerializeField] ParticleSystem deathExplosion;

    int currentHealth;

    public Action<int> OnDamageEvent;
    public Action<int> OnIncreaseHealthEvent;
    public Action OnDeathEvent;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        if (animator) animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            OnDamageEvent?.Invoke(currentHealth);
            Die();
        }
    }

    public void IncreaseHealth(int gain)
    {
        currentHealth = Mathf.Min(currentHealth + gain, maxHealth);
        OnIncreaseHealthEvent?.Invoke(currentHealth);
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
