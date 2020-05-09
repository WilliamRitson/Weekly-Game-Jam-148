using UnityEngine;


[RequireComponent(typeof(Controller))]
public class ProjectileLauncher : MonoBehaviour
{
    public float timeBetweenShots = 0.2f;
    public GameObject projectile;
    public GameObject firePoint;

    private Controller controller;
    private float timeSinceLastShot = 10.0f;

    private void Awake()
    {
        controller = GetComponent<Controller>();
        controller.OnLaunchProjectile += LaunchAtPosition;
    }

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }

    void LaunchAtPosition(Vector2 target)
    {
        if (timeSinceLastShot <= timeBetweenShots) return;
        Instantiate(projectile, firePoint.transform.position, transform.rotation);
        timeSinceLastShot = 0.0f;
    }
}
