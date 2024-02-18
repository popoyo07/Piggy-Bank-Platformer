using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyDeath : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private GameObject Prefav;
    private GameObject current;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
        Invoke("DestroyObject", 1f);
        SpawnObject();
    }
    private void SpawnObject()
    {

        Vector3 previousObjectPosition = transform.position;
        // Instantiate a new object based on the prefab
        current = Instantiate(Prefav, Vector3.zero, Quaternion.identity);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
