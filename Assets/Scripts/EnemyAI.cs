using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyAI : Controller
{
    GameObject player;
    private float maxEngagmentDist = 8;
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
        if ((transform.position - playerPos).sqrMagnitude > squaredMaxEngagmentDist)
        {
            movementDirection = Vector3.zero;
            return;
        }

        movementDirection = playerPos - transform.position;
        TriggerProjectileAttack(playerPos);
    }
}





