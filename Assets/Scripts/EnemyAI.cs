using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyAI : Controller
{
    public float moveSpeed = 5f;



    GameObject player;
    private float maxEngagmentDist = 8;
    private float squaredMaxEngagmentDist;

    //private Vector3 startingPosition;
    Vector3 playerPos;
    Vector2 movement;

    private Rigidbody2D rb;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        squaredMaxEngagmentDist = maxEngagmentDist * maxEngagmentDist;
        //startingPosition = transform.position;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerPos = player.transform.position;
        if ((transform.position - playerPos).sqrMagnitude > squaredMaxEngagmentDist)
        {
            movementDirection = Vector3.zero;
            return;
        }

        movementDirection = playerPos - transform.position;
        float angle = Mathf.Atan2(movementDirection.y, movementDirection.x)*Mathf.Rad2Deg;
        rb.rotation = angle;
        movementDirection.Normalize();
        movement = movementDirection;

        TriggerProjectileAttack(playerPos);
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (moveSpeed * direction * Time.deltaTime));
    }



    //private Vector3 PatrollingPosition()
    //{
    //    Vector3 randomDir = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    //    return startingPosition + randomDir * UnityEngine.Random.Range(10f, 50f); 
    //}



}





