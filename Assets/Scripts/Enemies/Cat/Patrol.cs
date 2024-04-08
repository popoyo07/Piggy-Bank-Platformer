using Unity.VisualScripting;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;
    
    [Header("movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behavior")]
    [SerializeField]private float idlDuration;
    private float idlTimer;

    [Header("enemy animator")]
    [SerializeField] private Animator anim;

    private void Awake()
    {
        initScale = transform.localScale;
       
    }

    private void OnDisable()
    {
        anim.SetBool("Walking", false);
    }
    private void Update()
    {
        Transform childTransform = transform.Find("CatBoss");

        if (childTransform == null)
        {
            // Child object not found
            Destroy(gameObject);
            Debug.Log("object not found");

        }
        if (movingLeft)
        {
            if (enemy.position.x > leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
                directionChange();

        }
        else
        {
            if (enemy.position.x < rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
                directionChange();
        }
    }

    private void directionChange()
    {
        anim.SetBool("Walking", false);

        idlTimer += Time.deltaTime;

        if (idlTimer > idlDuration)
        movingLeft = !movingLeft;
    }
    private void MoveInDirection(int _direction)
    {
        idlTimer = 0;
        anim.SetBool("Walking", true);

        // facing right direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * -1 * _direction,
            initScale.y, initScale.z);

        // moving direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }
}
