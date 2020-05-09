﻿using UnityEngine;
using System.Collections;
using System.Linq;

[RequireComponent(typeof(PlayerController))]
public class Shapeshifter : Controllable
{
    private float cooldown = 10f;
    private bool onCoolDown = false;
    private void Shapeshift(Vector2 target)
    {
        GameObject entity = Physics2D.OverlapCircleAll(target, 1)
            .First(col => col.GetComponent<EnemyAI>() != null).gameObject;
        GameObject newForm = Instantiate(entity, transform.position, transform.rotation);
        Destroy(newForm.GetComponent<EnemyAI>());
        newForm.AddComponent<Shapeshifter>();
        newForm.AddComponent<PlayerController>();
        newForm.tag = "Player";
        Destroy(gameObject);
    }

    protected override void AddController(Controller controller)
    {
        controller.OnShapeshift += Shapeshift;
    }

    protected override void RemoveController(Controller controller)
    {
        controller.OnShapeshift -= Shapeshift;
    }
}
