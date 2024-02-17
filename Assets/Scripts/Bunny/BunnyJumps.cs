using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class BunnyJumps : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private BoxCollider2D ColliderEnemyDeath;
    [SerializeField] private PolygonCollider2D ColliderPlayerDeath;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private float jumpForce;
   


    private float cooldownTimer = Mathf.Infinity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= jumpCooldown)
        {
            cooldownTimer = 0;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider == ColliderEnemyDeath)
        {
            Debug.Log("1");
        }
        if (other.collider == ColliderPlayerDeath)
        {
            Debug.Log(2);
        }
    }
}

