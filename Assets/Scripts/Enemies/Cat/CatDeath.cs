using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CatDeath : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private EnemiesHealth catHealth;
    [SerializeField] private GameObject Prefav;
    private GameObject current;

    // Custom event declaration
    public UnityEvent OnPlayerCollision;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        catHealth = GetComponent<EnemiesHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BounceKill"))
        {
            Debug.Log("Collision detected with: character bounce. Current Health " + catHealth.currentHealth);
            // Invoke the custom event
            OnPlayerCollision.Invoke();
            catHealth.takeDamage(1);
            Debug.Log("Remaining health "+ catHealth.currentHealth);
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

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
        SpawnObject();
        Invoke("DestroyObject", 0.7f);
      
    }

    private void SpawnObject()
    {
      
        // Instantiate a new object based on the prefab
        current = Instantiate(Prefav, transform.position, Quaternion.identity);
    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
