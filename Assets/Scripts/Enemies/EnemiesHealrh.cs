using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; } // making it accesible but value can only change in this method
    private Animator anim;
    private Rigidbody2D rb;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void takeDamage(float _damage)
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
    }
    /* private void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.CompareTag("Traps"))
         {
             Die();
         }
     }*/
}
