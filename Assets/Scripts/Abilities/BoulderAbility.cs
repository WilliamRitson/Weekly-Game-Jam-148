using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderAbility : Ability
{
    public GameObject boundingProjectile;
    //[SerializeField] private float bouncingAbilityDuration;
    [SerializeField] private float sizeMultiplier;

    private ProjectileLauncher projectileLauncher;
    private GameObject initialProjectile2D;

    private void Start()
    {
        projectileLauncher = GetComponent<ProjectileLauncher>();
        initialProjectile2D = projectileLauncher.projectile;

        if (boundingProjectile == null)
        {
            boundingProjectile = transform.GetChild(0).gameObject;
        }
    }

    public override bool ShouldUse(GameObject target)
    {
        return true;
    }

    public override void ActivateAbility(Vector2 target)
    {
        projectileLauncher.projectile = boundingProjectile;
        projectileLauncher.LaunchAtPosition(target - (Vector2)transform.position, 3, 15, 4);
        projectileLauncher.projectile = initialProjectile2D;
    }

}
