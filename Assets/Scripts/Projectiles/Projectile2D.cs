using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Projectile2D : MonoBehaviour
{
    public bool isTargetingPlayer;
    public float projectileVelocity;
    public int damage = 1;
    public Element damageType;
    public bool isAffetedBySquander;
    private Rigidbody2D rig;

    private void Start()
    {
        isAffetedBySquander = false;
        rig = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("proj colide with" + col.gameObject);
        Damagable damagable = col.collider.GetComponent<Damagable>();
        if (damagable) {
            damagable.TakeDamage(damage, damageType);
        }
        Destroy(gameObject);
    }

    public void GetAffectedBySquander()//let the pullet go away from the target when it affected by the suander (Wind Sheild ability)
    {
        isAffetedBySquander = true;
        rig.velocity = Vector2.zero;
        int rand = Random.Range(0, 2);

        if (rand == 0)
        {
            print("Affect");
            
            rig.AddForce(Vector2.right * projectileVelocity, ForceMode2D.Impulse);
        }
        else
        {
            rig.AddForce(Vector2.left * projectileVelocity, ForceMode2D.Impulse);
            print("Affect");
        }
    }
}
