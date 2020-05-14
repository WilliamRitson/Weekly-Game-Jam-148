using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingAbility : Ability
{
    public static bool hasTransformed = false;
    public static bool isHeInNormalShape = true;
    public Transform[] enemiesSummonPositions;//the positions where the enemies will be created after summon them
    public float secToShapeshitf = 15;//time to shapeshift the king
    public float secToBackToNormaleShape = 5;//time to finish the shapeshift pf the king and bring him back to it's normal shape
    public GameObject[] wizards;
    public GameObject king;
    private float lastShapeShiftTime;//the last time that the king shapshiftied


    private Shapeshifter shapeshifter;



    private void Start()
    {
        enemiesSummonPositions[0] = GameObject.FindGameObjectWithTag("Spawn1").transform;
        enemiesSummonPositions[1] = GameObject.FindGameObjectWithTag("Spawn2").transform;
        enemiesSummonPositions[2] = GameObject.FindGameObjectWithTag("Spawn3").transform;
        enemiesSummonPositions[3] = GameObject.FindGameObjectWithTag("Spawn4").transform;


        //if (king == null)
        //{
        //    king = GameObject.FindGameObjectWithTag("KingPrefab");
        //}
        lastShapeShiftTime = Time.time;
        shapeshifter = GetComponent<Shapeshifter>();
        if (hasTransformed)
        {
            StartCoroutine(BackToNormaleShape());
        }
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
        if (!hasTransformed)
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
                hasTransformed = true;
                //StartCoroutine(BackToNormaleShape());
            }
        }
    }

    public IEnumerator BackToNormaleShape()
    {
        yield return new WaitForSeconds(secToBackToNormaleShape);
        shapeshifter.Transform(king, false);
        hasTransformed = false;
    }
}
