using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CatDeath : MonoBehaviour
{
    private float startingHealth = 3f;
    public float currentHealth { get; private set; } // making it accessible but value can only change in this method
    private Animator anim;
    private Rigidbody2D rb;

    [SerializeField] private GameObject deathPrefab;
    private GameObject currentDeathObject;

    // Custom event declaration
    public UnityEvent OnPlayerCollision;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        Debug.Log(currentHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
        SpawnDeathObject();
        Invoke("DestroyEnemy", 0.7f);
    }

    private void SpawnDeathObject()
    {
        if (deathPrefab != null)
        {
            currentDeathObject = Instantiate(deathPrefab, transform.position, Quaternion.identity);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
        Debug.Log("Destroying enemy");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BounceKill"))
        {
            Debug.Log("Collision detected with: character bounce. Current Health " + currentHealth);
            // Invoke the custom event
            OnPlayerCollision.Invoke();
            TakeDamage(1);
            Debug.Log("Remaining health " + currentHealth);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health h = collision.gameObject.GetComponent<Health>();
            if (h != null)
            {
                // Execute the Die method of the Health component
                h.Diee(); // Assuming you have a Die() method in the Health script
            }
        }
    }
}
