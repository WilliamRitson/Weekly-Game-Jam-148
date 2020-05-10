using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTracer : MonoBehaviour
{

    [HideInInspector] public Transform target;
    
    [SerializeField] private Projectile2D Projectile2D;
    [SerializeField] private float secToDestroy;//seconds to destroy the projectile if it did not hit anything
    [SerializeField] private float trackingDuration;//time that the pullet will keep follow the target in it and after that time it'll go strieat till it destroy


    private float x, y, angle;
    private Rigidbody2D Projectile2DRig;
    private Transform playerTransform;
    private Vector2 projectileOldVelocity;//the vilocity which we throw tge projectile with
    private float creatTime;//the time when this projectile has been created

    // Start is called before the first frame update
    void Start()
    {
        creatTime = Time.time;
        Projectile2DRig = Projectile2D.GetComponent<Rigidbody2D>();
        projectileOldVelocity = Projectile2DRig.velocity;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if (Projectile2D.isTargetingPlayer)
        {
            target = playerTransform;
            Projectile2DRig.velocity = Vector2.zero;
        }

        Destroy(gameObject, secToDestroy);//destroy the projectile if it did not hit anything
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && Time.time - Time.deltaTime - creatTime <= trackingDuration && !Projectile2D.isAffetedBySquander)
        {
            if (Projectile2DRig.velocity != Vector2.zero)
            {
                Projectile2DRig.velocity = Vector2.zero;
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
    }
    private void FixedUpdate()
    {
        if (Time.time - Time.deltaTime - creatTime >= trackingDuration && !Projectile2D.isAffetedBySquander)
        {
            Projectile2DRig.velocity = Projectile2D.transform.right * Projectile2D.projectileVelocity;
        }
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
