using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] float moveSpeed;
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
        HandleMovement();
        HandleAttack();
    }

    /// <summary>
    /// Handle user input for movement
    /// </summary>
    void HandleMovement()
    {
        float hInput = Input.GetAxisRaw("Horizontal");

        if (hInput > 0)
        {
            rb.velocity = transform.right * moveSpeed;
        }
        else if (hInput < 0)
        {
            rb.velocity = -transform.right * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }


    /// <summary>
    /// Handle user input for attack
    /// </summary>
    void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextTimeToAttack)
        {
            Attack();
        }
    }

    /// <summary>
    /// Shoot missile
    /// </summary>
    void Attack()
    {
        if (!missilePf) return;

        Rigidbody2D rb2d = Instantiate(missilePf, transform.position + 1f * transform.up, Quaternion.identity).GetComponent<Rigidbody2D>();
        if (rb2d) rb2d.AddForce(attackForce * transform.up, ForceMode2D.Impulse);
        nextTimeToAttack = Time.time + attackCooldown;
    }
}
