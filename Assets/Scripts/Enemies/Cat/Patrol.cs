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

    [Header("enemy animator")]
    [SerializeField] private Animator anim;

    private void Awake()
    {
        initScale = transform.localScale;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
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
        movingLeft = !movingLeft;
    }
    private void MoveInDirection(int _direction)
    {
        anim.SetBool("Walking", true);

        // facing right direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * -1 * _direction,
            initScale.y, initScale.z);

        // moving direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }
}
