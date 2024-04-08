using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class BunnyDeath : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private GameObject Prefav;
    private GameObject current;
 

    // Custom event declaration
    public UnityEvent OnPlayerCollision;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BounceKill"))
        {
            Debug.Log("Collision detected with: " + collision.gameObject.name);
            // Invoke the custom event
            OnPlayerCollision.Invoke();
            Die();
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

        Vector3 previousObjectPosition = transform.position;
        // Instantiate a new object based on the prefab
        current = Instantiate(Prefav, transform.position, Quaternion.identity);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
