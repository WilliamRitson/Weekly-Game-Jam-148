using UnityEngine;


[RequireComponent(typeof(Controller))]
public class ProjectileLauncher : Controllable
{
    public float projectileVelocity = 6f;
    public float timeBetweenShots = 0.2f;
    public GameObject projectile;

    private Collider2D launcherCollider;
    private float timeSinceLastShot = 10.0f;

    private void Awake()
    {
        controller = GetComponent<Controller>();
        launcherCollider = GetComponent<Collider2D>();
        controller.OnLaunchProjectile += LaunchAtPosition;
    }


    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }

    void LaunchAtPosition(Vector2 target)
    {
        if (timeSinceLastShot <= timeBetweenShots) return;
        GameObject shot = Instantiate(projectile, transform.position, transform.rotation);
        if (launcherCollider)
        {
            Physics2D.IgnoreCollision(launcherCollider, shot.GetComponent<Collider2D>());
        }
        shot.GetComponent<Rigidbody2D>().velocity = (target - (Vector2)transform.position).normalized * projectileVelocity;
        timeSinceLastShot = 0.0f;
    }

    protected override void AddController(Controller controller)
    {
        controller.OnLaunchProjectile += LaunchAtPosition;
    }

    protected override void RemoveController(Controller controller)
    {
        controller.OnLaunchProjectile -= LaunchAtPosition;
    }
}
