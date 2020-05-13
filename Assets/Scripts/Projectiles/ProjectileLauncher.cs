using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ProjectileLauncher : Controllable
{
    public float projectileVelocity = 6f;
    public float timeBetweenShots = 0.2f;
    public GameObject projectile;
    public int damage = 1;
    public Element damageType;

    private Collider2D launcherCollider;
    private float timeSinceLastShot = 10.0f;
    private Animator animator;
    private AnimationManager animationManager;
    private Vector2 target;

    private void Awake()
    {
        animationManager = GetComponent<AnimationManager>();
        animator = GetComponent<Animator>();
        launcherCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }

    void LaunchIfAvalible(Vector2 target)
    {
        if (timeSinceLastShot <= timeBetweenShots) return;
        timeSinceLastShot = 0.0f;
        LaunchAtPosition(target);
    }

    public void LaunchAtPosition(Vector2 target)
    {
        this.target = target;
        animationManager.StartShootingAnimation();
    }

    public void LaunchInDirection(Vector2 target, float sizeMultilpier = 1, float lifetimeModifier = -1, int damageModifier = -1)
    {
        GameObject shot = Instantiate(projectile, transform.position, projectile.transform.rotation);
        float x = shot.transform.position.x;
        float y = shot.transform.position.y;

        x = x - target.x;
        y = y - target.y;
        float angle = Mathf.Atan2(x, y) * Mathf.Rad2Deg;
        shot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));

        //print(launcherCollider + " " + gameObject.name);
        if (launcherCollider)
        {
            Physics2D.IgnoreCollision(launcherCollider, shot.GetComponent<Collider2D>());
        }
        shot.GetComponent<Rigidbody2D>().velocity = -1 * shot.transform.up * projectileVelocity;
        // shot.transform.rotation = Quaternion.LookRotation(dir, Vector3.forward);
        if (sizeMultilpier != 1)
        {
            shot.transform.localScale *= sizeMultilpier;
        }
        if (lifetimeModifier != -1)
        {
            shot.GetComponent<Temporary>().lifespan = lifetimeModifier;
        }
       
        Projectile2D proj = shot.GetComponent<Projectile2D>();

        if (gameObject.CompareTag("Player"))
        {
            proj.isTargetingPlayer = false;
        }
        else
        {
            proj.isTargetingPlayer = true;
        }

        proj.projectileVelocity = projectileVelocity;
        proj.damage = damage;
        if (damageModifier != -1)
        {
            shot.GetComponent<Projectile2D>().damage += damageModifier;
        }
        proj.damageType = damageType;
        
    }

    protected override void AddController(Controller controller)
    {
        controller.OnLaunchProjectile += LaunchIfAvalible;
    }

    protected override void RemoveController(Controller controller)
    {
        controller.OnLaunchProjectile -= LaunchIfAvalible;
    }

    public void Shoot()//this function will be called from the AnimationManager
    {
        LaunchInDirection(target);
        
    }
}
