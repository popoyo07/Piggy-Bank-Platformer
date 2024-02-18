using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class BunnyJumps : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float jumpCooldown;
    [SerializeField] private float jumpForce;

    private Animator anim;
    private float cooldownTimer = Mathf.Infinity;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= jumpCooldown)
        {
            cooldownTimer = 0;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetTrigger("Jump");
        }
    }
}

