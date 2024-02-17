using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using Unity.VisualScripting;
using UnityEngine;

public class Bunnyatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("DustBunny")]
    [SerializeField] private Transform enemy;

    [Header("Movement")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingleft; 

    private void Awake()
    {
        initScale = enemy.localScale;
    }
    private void Update()
    {
    

            if (movingleft)
            {
                if (enemy.position.x >= leftEdge.position.x )
                {
                    MoveInDirection(-1);
              
                }
                else
                {
                    DirectionChange();
     
            }

            }
            else
            {
                if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
                else
                {
                    DirectionChange();
                }
            }
    }

    private void DirectionChange()
    {
        movingleft = !movingleft;
    }

    private void MoveInDirection(int _direction)
    {

        enemy.localScale = new Vector3(initScale.x * -1 * _direction, initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }
}
