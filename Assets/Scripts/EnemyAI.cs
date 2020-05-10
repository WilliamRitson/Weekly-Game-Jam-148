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

    Vector3 playerPos;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        squaredMaxEngagmentDist = maxEngagmentDist * maxEngagmentDist;
        playerPos = player.transform.position;

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

}





