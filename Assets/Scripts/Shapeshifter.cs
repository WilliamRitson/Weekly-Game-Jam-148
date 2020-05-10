using UnityEngine;
using System.Collections;
using System.Linq;

[RequireComponent(typeof(PlayerController))]
public class Shapeshifter : Controllable
{

    public float speedBonus = 1.0f;
    public float projectileCooldownMultiplier = 0.8f;
    public int lifeBonus = 2;

    private float cooldown = 10f;
    private bool onCoolDown = false;

    private void Start()
    {
        gameObject.tag = "Player";
    }

    private void Shapeshift(Vector2 target)
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
        newForm.AddComponent<CameraCenter>();
        newForm.AddComponent<PlayerController>();
        newForm.GetComponent<Mover>().initialSpeed += speedBonus;
        newForm.GetComponent<ProjectileLauncher>().timeBetweenShots *= projectileCooldownMultiplier;
        var health = newForm.GetComponent<Damagable>() ;
        health.MaximumLife += lifeBonus;
        health.CurrentLife = health.MaximumLife;
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
