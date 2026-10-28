using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Tilemaps;
using UnityEngine;

public class FishPatrol : MonoBehaviour
{
    // movement
    private float maxSpeed = 2f;
    private float acceleration = 1f;
    private float turnSpeed = 1.5f;

    // roaming
    private float directionChangeTime = 2f;

    private Vector2 velocity;
    private Vector2 targetDirection;
    private float directionTimer;



    private void Start()
    {
        // Pick a random starting direction
        targetDirection = Random.insideUnitCircle.normalized;

        if (targetDirection == Vector2.zero)
        {
            targetDirection = Vector2.right;
        }

        // Start the direction timer
        directionTimer = directionChangeTime;
    }

    private void Update()
    {
        ChooseDirection();
        Move();
    }



    private void ChooseDirection()
    {
        directionTimer -= Time.deltaTime;

        if (directionTimer <= 0)
        {
            // Pick a new random direction
            targetDirection = Random.insideUnitCircle.normalized;

            if (targetDirection == Vector2.zero)
            {
                targetDirection = Vector2.right;
            }

            // Pick a random amount of time before changing direction again
            directionTimer = Random.Range(
                directionChangeTime * 0.5f,
                directionChangeTime * 1.5f
            );
        }
    }

    private void Move()
    {
        // Gradually turn toward the desired direction
        Vector2 newDirection = Vector2.Lerp(
            velocity.normalized,
            targetDirection,
            turnSpeed * Time.deltaTime
        ).normalized;

        // Gradually accelerate
        float targetSpeed = maxSpeed;

        float currentSpeed = velocity.magnitude;

        currentSpeed = Mathf.MoveTowards(
            currentSpeed,
            targetSpeed,
            acceleration * Time.deltaTime
        );

        velocity = newDirection * currentSpeed;

        // Move the fish
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}