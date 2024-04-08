using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
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
            Diee();
        }
    }



    internal void Diee()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
        Invoke("LoadScene1", 1f);
    }

    public void LoadScene1()
    {
        SceneManager.LoadSceneAsync("GameOver"); // Replace "Scene1" with the actual name of your first scene
    }
    /* private void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.CompareTag("Traps"))
         {
             Die();
         }
     }*/
}
