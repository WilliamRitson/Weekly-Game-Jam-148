using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityMeter : MonoBehaviour
{
    private IDisplayAbility ability;

    public IDisplayAbility Ability { get => ability; set => SetAbility(value); }

    [SerializeField] private Image imageDisplay;
    [SerializeField] private Text tooltip;
    public string key;
    private float cooldownTime;
    private float cooldownTimeTotal;

    private void SetAbility(IDisplayAbility newAbility)
    {
        if (ability != null)
        {
            ability.OnCooldown -= StartCooldown;
        }

        ability = newAbility;
        if (newAbility == null)
        {
            gameObject.SetActive(false);
            return;
        }
        else
        {
            gameObject.SetActive(true);
        }
        imageDisplay.sprite = newAbility.Icon;
        newAbility.OnCooldown += StartCooldown;
        tooltip.text = key + ": Use " + newAbility.Name;
    }

    private void OnDestroy()
    {
        ability.OnCooldown -= StartCooldown;
    }

    private void StartCooldown(float time)
    {
        cooldownTimeTotal = cooldownTime = time;
    }

    private void Update()
    {
        cooldownTime -= Time.deltaTime;
    }
}
