using System.Collections;
using UnityEngine;

public abstract class Ability : Controllable
{
    public float cooldownTime = 10.0f;
    private bool onCooldown = false;
    protected float lastUsed = Mathf.Infinity;

    protected virtual void Trigger(Vector2 target)
    {
        if (onCooldown) return;
        onCooldown = true;
        StartCoroutine(Cooldown());
        ActivateAbility(target);
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        onCooldown = false;
    }

    public abstract bool ShouldUse(GameObject target);

    protected abstract void ActivateAbility(Vector2 target);

    protected override void AddController(Controller controller)
    {
        controller.OnActivateAbility += Trigger;
    }

    protected override void RemoveController(Controller controller)
    {
        controller.OnActivateAbility -= Trigger;
    }
}
