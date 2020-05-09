using UnityEngine;

public class ProjectileLauncher : Controllable
{
    public float projectileVelocity = 6f;
    public float timeBetweenShots = 0.2f;
    public GameObject projectile;
    public int damage = 1;
    public Element damageType;

    private Collider2D launcherCollider;
    private float timeSinceLastShot = 10.0f;

    private void Awake()
    {
        launcherCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }

    void LaunchIfAvalible(Vector2 target)
    {
        if (timeSinceLastShot <= timeBetweenShots) return;
        LaunchAtPosition(target);
    }

    public void LaunchAtPosition(Vector2 target)
    {
        LaunchInDirection(target - (Vector2)transform.position);
    }

    public void LaunchInDirection(Vector2 dir)
    {
        GameObject shot = Instantiate(projectile, transform.position, transform.rotation);
        if (launcherCollider)
        {
            Physics2D.IgnoreCollision(launcherCollider, shot.GetComponent<Collider2D>());
        }
        shot.GetComponent<Rigidbody2D>().velocity = dir.normalized * projectileVelocity;
        Projectile2D proj = shot.GetComponent<Projectile2D>();
        proj.projectileVelocity = projectileVelocity;
        proj.damage = damage;
        proj.damageType = damageType;
        timeSinceLastShot = 0.0f;
    }

    protected override void AddController(Controller controller)
    {
        controller.OnLaunchProjectile += LaunchIfAvalible;
    }

    protected override void RemoveController(Controller controller)
    {
        controller.OnLaunchProjectile -= LaunchIfAvalible;
    }
}
