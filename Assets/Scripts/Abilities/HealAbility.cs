using UnityEngine;

[RequireComponent(typeof(Damagable))]
public class HealAbility : Ability
{
    public int healAmount = 3;

    Damagable dmg;
    private void Awake()
    {
        dmg = GetComponent<Damagable>();
    }

    public override void ActivateAbility(Vector2 target)
    {
        dmg.Heal(healAmount);
    }

    public override bool ShouldUse(GameObject target)
    {
        return (dmg.MaximumLife - dmg.CurrentLife) >= healAmount;
    }
}
