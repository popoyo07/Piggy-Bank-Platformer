using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BunnyPatriol : MonoBehaviour
{
    [SerializeField] private GameObject RightEdge;
    [SerializeField] private GameObject leftEdge;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    [SerializeField] float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = RightEdge.transform;
        anim.SetBool("Moving");
    }
    private void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == RightEdge)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(speed, 0);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.6f && currentPoint == RightEdge)
        {
            currentPoint = leftEdge.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.6f && currentPoint == leftEdge)
        {
            currentPoint = RightEdge.transform;
        }
    }

}
