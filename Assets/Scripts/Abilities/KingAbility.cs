using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingAbility : Ability
{
    public Transform[] enemiesSummonPositions;//the positions where the enemies will be created after summon them
    public float secToShapeshitf;//time to shapeshift the king
    public GameObject[] wizards;
    //public ProjectileSquander squander;
    //public BouncingProjectile bouncingProjectile;

    private float lastShapeShiftTime;//the last time that the king shapshiftied

    //private BoulderAbility boulderAbility;
    //private Flamethrower flamethrower;
    //private HealAbility healAbility;
    //private WindShieldAbility windShieldAbility;
    //private VolleyAbility volleyAbility;
    private Shapeshifter shapeshifter;

    //protected override void Trigger(Vector2 target)
    //{
    //    if (onCooldown) return;
    //    MovingTextManager.Instance.ShowMessage(Name, transform.position, Color.white);
    //    StartCooldown();
    //    ActivateAbility(target);
    //}

    private void Start()
    {
        lastShapeShiftTime = Time.time;

        //boulderAbility = GetComponent<BoulderAbility>();
        //flamethrower = GetComponent<Flamethrower>();
        //healAbility = GetComponent<HealAbility>();
        //windShieldAbility = GetComponent<WindShieldAbility>();
        //volleyAbility = GetComponent<VolleyAbility>();
        //TryGetComponent(out boulderAbility);
        //TryGetComponent(out flamethrower);
        //TryGetComponent(out healAbility);
        //TryGetComponent(out windShieldAbility);
        //TryGetComponent(out volleyAbility);
        shapeshifter = GetComponent<Shapeshifter>();

        //windShieldAbility.projectileSquander = squander;
    }

    public override bool ShouldUse(GameObject target)
    {
        if (Time.time - lastShapeShiftTime >= secToShapeshitf)
        {
            return true;
        }
        print(lastShapeShiftTime);
        return false;
    }

    public override void ActivateAbility(Vector2 target)
    {
        if (Time.time - lastShapeShiftTime >= secToShapeshitf)
        {
            lastShapeShiftTime = Time.time;

            int abilityNum = Random.Range(0, 4);

            switch (abilityNum)
            {
                case 0: shapeshifter.SetShapeshitType(Shapeshifter.earthShifshape); break;
                case 1: shapeshifter.SetShapeshitType(Shapeshifter.fireShifshape); break;
                case 2: shapeshifter.SetShapeshitType(Shapeshifter.waterShifshape); break;
                case 3: shapeshifter.SetShapeshitType(Shapeshifter.windShifshape); break;

                default:
                    break;
            }

            for (int i = 0; i < enemiesSummonPositions.Length; i++)
            {
                Instantiate(wizards[abilityNum], enemiesSummonPositions[i].position, Quaternion.identity);
            }

            shapeshifter.Transform(wizards[abilityNum], false);




            //switch (abilityNum)
            //{
            //    case 0: boulderAbility.ActivateAbility(Vector2.zero); print(boulderAbility); break;
            //    case 1: flamethrower.ActivateAbility(target); print(flamethrower); break;
            //    case 2: healAbility.ActivateAbility(Vector2.zero); print(healAbility); break;
            //    case 3: windShieldAbility.ActivateAbility(Vector2.zero); print(windShieldAbility); break;
            //    case 4: volleyAbility.ActivateAbility(Vector2.zero); print(volleyAbility); break;

            //    default:
            //        break;
            //}
        }
    }
}
