using System;
using System.Collections;
using UnityEngine;

public abstract class Ability : Controllable, IDisplayAbility
{
    protected ProjectileLauncher projectileLauncher;

    public float cooldownTime = 10.0f;
    private bool onCooldown = false;
    protected float lastUsed = Mathf.Infinity;

    public event Action<float> OnCooldown;
    [SerializeField] protected Sprite icon;
    public Sprite Icon { get => icon; }
    [SerializeField] protected string abilityName;
    public string Name { get => abilityName; }


    private void Awake()
    {
        projectileLauncher = GetComponent<ProjectileLauncher>();
    }

    protected virtual void Trigger(Vector2 target)
    {
        if (onCooldown) return;
        MovingTextManager.Instance.ShowMessage(Name, transform.position, Color.white);
        StartCooldown();
        ActivateAbility(target);
    }
    
    protected void StartCooldown()
    {
        onCooldown = true;
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        OnCooldown?.Invoke(cooldownTime);
        yield return new WaitForSeconds(cooldownTime);
        onCooldown = false;
    }

    public abstract bool ShouldUse(GameObject target);

    public abstract void ActivateAbility(Vector2 target);

    protected override void AddController(Controller controller)
    {
        controller.OnActivateAbility += Trigger;
    }

    protected override void RemoveController(Controller controller)
    {
        controller.OnActivateAbility -= Trigger;
    }
}
