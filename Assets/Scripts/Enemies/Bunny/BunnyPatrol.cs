using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BunnyPatriol : MonoBehaviour
{
    public GameObject RightEdge;
    public GameObject leftEdge;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    [SerializeField] private CircleCollider2D cir;
    public float speed;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = RightEdge.transform;
        anim.SetBool("Moving", true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Directions"))
        {
            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == RightEdge)
            {
                Flip();
                currentPoint = leftEdge.transform;
                Debug.Log("flip Left");

            }
            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == leftEdge)
            {
                Flip();
                currentPoint = RightEdge.transform;
                Debug.Log("flip Right");
            }
        }
    }
    private void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == RightEdge)
        {
            rb.velocity = new Vector2(speed, 0);
            Debug.Log("moving Right");
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
            Debug.Log("moving Left");

        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == RightEdge)
        {
            Flip();
            currentPoint = leftEdge.transform;
            Debug.Log("flip Left");

        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == leftEdge)
        {
            Flip();
            currentPoint = RightEdge.transform;
            Debug.Log("flip Right");
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(RightEdge.transform.position, 0.5f);
        Gizmos.DrawWireSphere(leftEdge.transform.position, 0.5f);

    }
}
