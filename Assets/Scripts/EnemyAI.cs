using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyAI : Controller
{
    GameObject player;

    [SerializeField]
    private float maxEngagmentDist = 8.0f;
    [SerializeField]
    private float rememberPlayerTime = 2.0f;
    private float lastSawPlayer = Mathf.Infinity;

    private float squaredMaxEngagmentDist;

    private void Awake()
    {
        squaredMaxEngagmentDist = maxEngagmentDist * maxEngagmentDist;
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (!player) return;
        }

        Vector3 playerPos = player.transform.position;
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
