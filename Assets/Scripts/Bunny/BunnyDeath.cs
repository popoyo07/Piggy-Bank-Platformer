using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyDeath : MonoBehaviour
{
    [SerializeField] BoxCollider2D BoxColiderKill;
    [SerializeField] BoxCollider2D BoxColiderDeath;

    private Animator anim;
    private Rigidbody2D rb;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider == BoxColiderKill)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                // Lower collider kills the player
                Die();
                Destroy(other.gameObject);  // Destroy the player
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == BoxColiderDeath)
        {
            // Upper collider destroys itself
            Destroy(gameObject);
        }
    }
}
