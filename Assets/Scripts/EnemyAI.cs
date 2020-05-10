using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyAI : Controller
{
    public float moveSpeed = 5f;



    GameObject player;

    [SerializeField]
    private float maxEngagmentDist = 8.0f;
    [SerializeField]
    private float rememberPlayerTime = 2.0f;
    private float lastSawPlayer = Mathf.Infinity;

    private float squaredMaxEngagmentDist;
    private Ability ability;

    //private Vector3 startingPosition;
    Vector3 playerPos;
    Vector2 movement;

    private Rigidbody2D rb;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        squaredMaxEngagmentDist = maxEngagmentDist * maxEngagmentDist;
        playerPos = player.transform.position;

        //startingPosition = transform.position;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        ability = GetComponent<Ability>();

    }

    void Update()
    {

        playerPos = player.transform.position;
        if ((transform.position - playerPos).sqrMagnitude > squaredMaxEngagmentDist)

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (!player) return;
        }

        if (CanSeePlayer(playerPos))
        {
            lastSawPlayer = 0;
        }
        else
        {
            lastSawPlayer += Time.deltaTime;
        }

        if (lastSawPlayer > rememberPlayerTime)
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
        if (ability != null && ability.ShouldUse(player))
        {
            TriggerAbility(playerPos);
        }
    }

    bool CanSeePlayer(Vector3 playerPos)
    {
        if ((transform.position - playerPos).sqrMagnitude > squaredMaxEngagmentDist)
        {
            return false;
        }
        RaycastHit2D cast = Physics2D.Raycast(transform.position, playerPos - transform.position);
        return cast.collider.gameObject == player;
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





