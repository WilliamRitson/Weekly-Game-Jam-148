using UnityEngine;


[RequireComponent(typeof(Damagable))]
public abstract class OnDeathBehavior : MonoBehaviour
{
    private Damagable damagable;

    private void Start()
    {
        damagable = GetComponent<Damagable>();
        damagable.OnDeath += OnDeath;
    }

    private void OnDestroy()
    {
        damagable.OnDeath -= OnDeath;
    }

    protected abstract void OnDeath();
}

[RequireComponent(typeof(Damagable))]
public abstract class OnDamageBehavior : MonoBehaviour
{
    private Damagable damagable;

    private void Start()
    {
        damagable = GetComponent<Damagable>();
        damagable.OnDamaged += OnDamaged;
    }

    private void OnDestroy()
    {
        damagable.OnDamaged -= OnDamaged;
    }

    protected abstract void OnDamaged(int damage);
}

[RequireComponent(typeof(Damagable))]
public abstract class OnHealthChangeBehavior : MonoBehaviour
{
    private Damagable damagable;

    private void Start()
    {
        damagable = GetComponent<Damagable>();
        damagable.OnHealthChange += OnHealthChange;
    }

    private void OnDestroy()
    {
        damagable.OnHealthChange -= OnHealthChange;
    }

    protected abstract void OnHealthChange(int health);
}