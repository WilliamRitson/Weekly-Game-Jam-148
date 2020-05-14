using System;
using System.Collections.Generic;
using UnityEngine;


public class Damagable : MonoBehaviour
{
    [Tooltip("The maximum health this entity can have.")]
    [SerializeField] private int maximumLife;
    public int MaximumLife { get => maximumLife; set => SetMaximumHealth(value); }

    [Tooltip("The initial amount of health this entity should start with.")]
    [SerializeField] private int currentLife;
    public int CurrentLife { get => currentLife; set => SetHealth(value); }

    [SerializeField]
    private Element weakness;

    [SerializeField]
    private Element resistance;

    /// <summary> An event fired when the entity hits 0 health. </summary>
    public event Action OnDeath;

    /// <summary> An event fired whenever the entity's health changes. </summary>
    public event Action<int> OnHealthChange;

    /// <summary> An event fired whenever the entity takes damage </summary>
    public event Action<int> OnDamaged;

    /// <summary>Sets the health of this entity bounded between 0 and the maximumLife value.</summary>
    /// <returns>The change from the previous value.</returns>
    public int SetHealth(int newValue)
    {
        if (currentLife == newValue)
            return 0;
        int previous = currentLife;
        currentLife = Math.Min(Math.Max(0, newValue), maximumLife);
        OnHealthChange?.Invoke(currentLife);
        if (currentLife == 0)
        {
            OnDeath?.Invoke();
        }

        return Math.Abs(previous - currentLife);
    }

    /// <summary>Sets the health of this entity to a value greater than 0. 
    /// If the maximum health is less than the current health updates the current health to be the maximum health</summary>
    /// <returns>The change from the previous value.</returns>
    public int SetMaximumHealth(int newValue)
    {
        if (currentLife == newValue)
            return 0;
        int previous = currentLife;
        maximumLife = Math.Max(0, newValue);
        if (maximumLife < currentLife)
        {
            SetHealth(maximumLife);
        }
        return previous - currentLife;
    }

    private int GetEffectiveDamage(int damage, Element element)
    {
        int effective = damage;
        if (element == weakness)
        {
            effective = damage * 2;
            MovingTextManager.Instance.ShowMessage("Super Effective -" + effective, transform.position, Color.red);
        }
        else if (element == resistance)
        {
            effective = Math.Max(1, damage / 2);
            MovingTextManager.Instance.ShowMessage("Ineffective -" + effective, transform.position, Color.red);
        }
        else
        {
            MovingTextManager.Instance.ShowMessage("-" + effective, transform.position, Color.red);
        }
        return effective;
    }

    /// <summary>Reduces health by the given amount.</summary>
    /// <returns>The change from the previous value.</returns>
    public int TakeDamage(int damage, Element element)
    {
        damage = GetEffectiveDamage(damage, element);
        int resultantDamage = SetHealth(currentLife - damage);
        if (resultantDamage > 0)
        {
            AudioManager.SharedInstance().PlayDamageAudio();
            OnDamaged?.Invoke(resultantDamage);
        }
        return resultantDamage;
    }

    public int Heal(int healAmount)
    {
        int healed = SetHealth(currentLife + healAmount);
        MovingTextManager.Instance.ShowMessage("+" + healed, transform.position, Color.green);
        return healed;
    }
}
