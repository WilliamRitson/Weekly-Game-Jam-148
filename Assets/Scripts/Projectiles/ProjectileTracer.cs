using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTracer : MonoBehaviour
{

    [HideInInspector] public Transform target;

    [SerializeField] private float secToDestroy;//seconds to destroy the projectile if it did not hit anything

    private float x, y, angle;
    private Rigidbody2D rig;
    private Projectile2D Projectile2D;


    // Start is called before the first frame update
    void Start()
    {
        Projectile2D = GetComponent<Projectile2D>();
        rig = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rig.velocity = Vector2.zero;

        Destroy(gameObject, secToDestroy);//destroy the projectile if it did not hit anything
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            x = transform.position.x;
            y = transform.position.y;

            x = x - target.position.x;
            y = y - target.position.y;
            angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.Rotate(new Vector3(0, 0, 180));
            transform.position += transform.right * Projectile2D.projectileVelocity * Time.deltaTime ;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
