using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb; 
    private BoxCollider2D coli;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;

    private float dirx = 0f; 

    [SerializeField] private float moveSpeed; // place holder for speed and force
    [SerializeField] private float jumpForce;

    private enum MovementState { idl, running, junmping, falling } // here is making a custom value variable so I can track animatinos. Their position means 0, 1, 2, 3 and so on

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coli = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>(); // conects with the animation components so I can use them in variables
        sprite = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    private void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirx * moveSpeed, rb.velocity.y); //Movement in Direction 


        //   || Input.GetKeyDown("'W' key")
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        updateAnimation();
        CheckForQuitInput();


    }

    private void updateAnimation()
    {
        MovementState state;

        if (dirx > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirx < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idl;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.junmping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("State", (int)state);
    } 

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coli.bounds.center,
            coli.bounds.size,
            0f, Vector2.down,
            .1f,
            jumpableGround); // reading so can the player can only jump when is touching the ground 
    }

    void CheckForQuitInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            QuitGame();
        }
    }

    // Function to quit the game
    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
