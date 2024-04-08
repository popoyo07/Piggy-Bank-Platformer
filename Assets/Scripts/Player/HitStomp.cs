using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStomp : MonoBehaviour
{
    [SerializeField] float bounce;
    [SerializeField] Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Get reference to CatDeath script
            CatDeath catDeath = collision.gameObject.GetComponent<CatDeath>();
            if (catDeath != null)
            {
                // Invoke the custom event in CatDeath script
                catDeath.OnPlayerCollision.Invoke();
                rb.velocity = new Vector2(rb.velocity.x, bounce);
            }

            BunnyDeath bunnyDeath = collision.gameObject.GetComponent<BunnyDeath>();
            if (bunnyDeath != null)
            {
                // Invoke the custom event in BunnyDeath script
                bunnyDeath.OnPlayerCollision.Invoke();
                rb.velocity = new Vector2(rb.velocity.x, bounce);
            }
        }
    }
}
