using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BunnyAttack: MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int dmg;
    [SerializeField] private CircleCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;
    private Health playerhealth;

    private BunnyPatrol patrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        patrol = GetComponentInParent<BunnyPatrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;


        //Attack only when Player in sight
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("Atk");
                Debug.Log("atacking");
            }
        }
        if (patrol != null)
            patrol.enabled = !PlayerInSight();
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);
        if (hit.collider != null)
        {
            playerhealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos() // this is to track the range of enemy
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerhealth.takeDamage(dmg);
            Debug.Log("doing dmg" + playerhealth.currentHealth);
        }

    }
}
