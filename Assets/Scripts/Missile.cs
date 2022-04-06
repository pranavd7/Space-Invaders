using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] string tagToCompare;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagToCompare))
        {
            Health health = collision.GetComponent<Health>();
            if (health) health.TakeDamage(damage);

            Destroy(gameObject);
        }
        else if (collision.CompareTag("Missile"))
        {
            Destroy(gameObject);
        }
    }


    private void OnBecameInvisible()
    {
        //Destroy the object when out of the screen bounds
        Destroy(gameObject);
    }
}
