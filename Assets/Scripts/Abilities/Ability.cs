using UnityEngine;

public abstract class Ability : Controllable
{
    public float cooldownTime = 10.0f;
    private float lastUsed = Mathf.Infinity;

    void Trigger(Vector2 target)
    {
        if (lastUsed < cooldownTime) return;
        lastUsed = 0;
        ActivateAbility(target);
    }

    private void Update()
    {
        lastUsed += Time.deltaTime;
    }

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
