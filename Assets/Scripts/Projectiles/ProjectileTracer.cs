using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTracer : MonoBehaviour
{

    [HideInInspector] public Transform target;
    
    [SerializeField] private Projectile2D Projectile2D;
    [SerializeField] private float secToDestroy;//seconds to destroy the projectile if it did not hit anything

    private float x, y, angle;
    private Rigidbody2D rig;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        rig = Projectile2D.GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if (Projectile2D.isTargetingPlayer)
        {
            target = playerTransform;
            rig.velocity = Vector2.zero;
        }

        Destroy(gameObject, secToDestroy);//destroy the projectile if it did not hit anything
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if (rig.velocity != Vector2.zero)
            {
                rig.velocity = Vector2.zero;
            }

            x = Projectile2D.transform.position.x;
            y = Projectile2D.transform.position.y;

            x = x - target.position.x;
            y = y - target.position.y;
            angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            Projectile2D.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            Projectile2D.transform.Rotate(new Vector3(0, 0, 180));
            Projectile2D.transform.position += Projectile2D.transform.right * Projectile2D.projectileVelocity * Time.deltaTime;
        }
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (target == null)
        {
            if (!Projectile2D.isTargetingPlayer && collision.tag == "Enemy")
            {
                target = collision.transform;
            }
            //if (Projectile2D.isTargetingPlayer && collision.tag == "Player")
            //{
            //    target = playerTransform;
            //}
        }
    }
}
