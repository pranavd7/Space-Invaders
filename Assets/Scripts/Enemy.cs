using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float attackForce = 10f;
    [SerializeField] float attackCooldown;
    [SerializeField] GameObject missilePf;

    Rigidbody2D rb;
    float nextTimeToAttack;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        nextTimeToAttack = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!missilePf) return;
        if (Time.time > nextTimeToAttack)
        {
            Rigidbody2D rb2d = Instantiate(missilePf, transform.position - 1f * transform.up, Quaternion.identity).GetComponent<Rigidbody2D>();
            if (rb2d) rb2d.AddForce(-attackForce * transform.up, ForceMode2D.Impulse);
            nextTimeToAttack = Time.time + attackCooldown;
        }
    }
}
