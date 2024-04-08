using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CatAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    private int dmg = 3;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;
    private Health playerhealth;

    private Patrol catPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        catPatrol = GetComponentInParent<Patrol>();

        AdjustAttackColliderSize();
    }

    private void AdjustAttackColliderSize()
    {
        // Create a new collider with the desired size
        BoxCollider2D newCollider = gameObject.AddComponent<BoxCollider2D>();
        newCollider.size = new Vector2(boxCollider.size.x, boxCollider.size.y * 0.5f);

        // Disable the original collider
        boxCollider.enabled = false;

        // Assign the new collider as the attack box collider
        boxCollider = newCollider;
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
                anim.SetTrigger("Attk");
                Debug.Log("atacking");
                DamagePlayer();

            }
        }
        if(catPatrol != null)
            catPatrol.enabled = !PlayerInSight();
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
