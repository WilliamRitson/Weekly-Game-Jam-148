using UnityEngine;
using System.Linq;
using System;

[RequireComponent(typeof(PlayerController))]
public class Shapeshifter : Ability
{

    public float speedBonus = 1.0f;
    public float projectileCooldownMultiplier = 0.8f;
    public int lifeBonus = 2;


    private void Start()
    {
        gameObject.tag = "Player";
        var playerUI = GameObject.FindGameObjectWithTag("PlayerUI").GetComponent<PlayerUI>();
        playerUI.AttachTo(this, GetComponents<Ability>().FirstOrDefault(abilty => abilty != this));
    }

    protected override void ActivateAbility(Vector2 target)
    {
        var shiftable = Physics2D.OverlapCircleAll(target, 1)
            .FirstOrDefault(col => col.GetComponent<EnemyAI>() != null);
        if (!shiftable) return;

        Transform(shiftable.gameObject);
    }


    private void Transform(GameObject toCopy)
    {
        GameObject newForm = Instantiate(toCopy, transform.position, transform.rotation);
        Destroy(newForm.GetComponent<EnemyAI>());
        newForm.AddComponent<Shapeshifter>();
        Shapeshifter shift = newForm.GetComponent<Shapeshifter>();
        shift.icon = icon;
        shift.abilityName = abilityName;
        shift.speedBonus = speedBonus;
        shift.projectileCooldownMultiplier = projectileCooldownMultiplier;
        shift.lifeBonus = lifeBonus;
        newForm.AddComponent<CameraCenter>();
        newForm.AddComponent<PlayerController>();
        newForm.GetComponent<Mover>().initialSpeed += speedBonus;
        newForm.GetComponent<ProjectileLauncher>().timeBetweenShots *= projectileCooldownMultiplier;
        var health = newForm.GetComponent<Damagable>();
        health.MaximumLife += lifeBonus;
        health.CurrentLife = health.MaximumLife;
        shift.StartCooldown();
        Destroy(gameObject);
    }

    protected override void AddController(Controller controller)
    {
        controller.OnShapeshift += ActivateAbility;
    }

    protected override void RemoveController(Controller controller)
    {
        controller.OnShapeshift -= ActivateAbility;
    }

    public override bool ShouldUse(GameObject target)
    {
        throw new NotImplementedException();
    }


}
