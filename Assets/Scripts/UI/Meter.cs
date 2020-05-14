using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meter : MonoBehaviour
{
    [SerializeField] private Image fill;
    [SerializeField] private Text display;
    private Damagable dmg;
    private float max;

    internal void ConnectDamagable(Damagable health)
    {
        if (dmg != null) 
            DisconnectDamagable(dmg);
        dmg = health;
        health.OnHealthChange += SetHealth;
        max = health.MaximumLife;
        SetHealth(health.CurrentLife);
    }

    internal void DisconnectDamagable(Damagable health)
    {
        health.OnHealthChange -= SetHealth;
    }

    private void OnDestroy()
    {
        if (dmg != null) 
            DisconnectDamagable(dmg);
    }


    protected virtual void SetHealth(int newValue)
    {
        display.text = newValue + "/" + (int) max;
        fill.fillAmount = newValue / max ;
    }
}
