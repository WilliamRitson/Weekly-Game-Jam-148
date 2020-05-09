using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyAI : Controller
{
    GameObject player;
    private float maxEngagmentDist = 8;

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (!player) return;
        }
        Vector3 playerPos = player.transform.position;
        if ((transform.position - playerPos).sqrMagnitude > (maxEngagmentDist * maxEngagmentDist))
            return;


        movementDirection = playerPos - transform.position;
        TriggerProjectileAttack(playerPos);
    }


}
