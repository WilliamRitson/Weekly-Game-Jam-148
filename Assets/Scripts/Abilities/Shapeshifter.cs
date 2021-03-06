﻿using UnityEngine;
using System.Linq;
using System;

//[RequireComponent(typeof(PlayerController))]
public class Shapeshifter : Ability
{
    public const string earthShifshape = "Earth";
    public const string fireShifshape = "Fire";
    public const string waterShifshape = "Water";
    public const string windShifshape = "Wind";
    public GameObject baseForm;

    public float speedBonus = 1.0f;
    public float projectileCooldownMultiplier = 0.8f;
    public int lifeBonus = 2;
    private bool justShifted = false;
    private string shapeshiftType;

    private KingAbility kingAbility;



    private void Start()
    {
        if (!TryGetComponent(out kingAbility))// if it's not king
        {
            
            gameObject.tag = "Player";
            var playerUI = GameObject.FindGameObjectWithTag("PlayerUI").GetComponent<PlayerUI>();
            var dmg = GetComponent<Damagable>();
            playerUI.AttachTo(this, GetComponents<Ability>().FirstOrDefault(abilty => abilty != this), dmg);

            if (justShifted)
            {
                StartCooldown();
            }
        }
    }

    private Collider2D GetTargetEntity(Vector2 target)
    {
        return Physics2D.OverlapCircleAll(target, 2)
            .FirstOrDefault(col => col.GetComponent<EnemyAI>() != null);
    }

    public override void ActivateAbility(Vector2 target)
    {
        var shiftable = GetTargetEntity(target);
        if (!shiftable) return;

        Transform(shiftable.gameObject, true);
        AudioManager.SharedInstance().PlayShapeShiftAudio();
    }

    protected override bool CanUse(Vector2 target)
    {
        return GetTargetEntity(target) != null;
    }


    public void Transform(GameObject toCopy, bool isItPlayer)//if it's not a player the it's a king
    {
        GameObject newForm = Instantiate(toCopy, transform.position, transform.rotation);
        newForm.AddComponent<Shapeshifter>();
        Shapeshifter shift = newForm.GetComponent<Shapeshifter>();
        shift.icon = icon;
        shift.abilityName = abilityName;
        shift.cooldownTime = cooldownTime;
        shift.speedBonus = speedBonus;
        shift.projectileCooldownMultiplier = projectileCooldownMultiplier;
        shift.lifeBonus = lifeBonus;
        shift.justShifted = true;

        
        

        if (isItPlayer)
        {

            var health = newForm.GetComponent<Damagable>();
            health.MaximumLife += lifeBonus;
            health.CurrentLife = health.MaximumLife;

            Destroy(newForm.GetComponent<EnemyAI>());
            Destroy(newForm.GetComponent<DestroyOnDeath>());


            newForm.AddComponent<CameraCenter>();
            newForm.AddComponent<ChangeSceneOnDeath>();
            newForm.AddComponent<PlayerController>();
            newForm.GetComponent<Mover>().initialSpeed += speedBonus;
            newForm.GetComponent<ProjectileLauncher>().timeBetweenShots *= projectileCooldownMultiplier;
            newForm.gameObject.name = "Player";
            newForm.gameObject.tag = "Player";
        }
        else
        {
            newForm.layer = 0;//give him the layer default (to not give him the layer enemy and by that we prevent the player from shapeshift to it even wehn he is a wizard)
            newForm.gameObject.name = "King";

            switch (shapeshiftType)
            {
                case earthShifshape: newForm.AddComponent<BoulderAbility>(); break;
                case fireShifshape: newForm.AddComponent<Flamethrower>(); break;
                case waterShifshape: newForm.AddComponent<HealAbility>(); break;
                case windShifshape: newForm.AddComponent<WindShieldAbility>(); break;

                default:
                    break;
            }

            KingAbility newKingAbility = newForm.AddComponent<KingAbility>();
            newKingAbility.wizards = kingAbility.wizards;
            newKingAbility.enemiesSummonPositions = kingAbility.enemiesSummonPositions;
            newKingAbility.secToShapeshitf = kingAbility.secToShapeshitf;
            newKingAbility.secToShapeshitf = kingAbility.secToBackToNormaleShape;
            newKingAbility.king = kingAbility.king;

        }


        Destroy(gameObject);
    }

    protected override void AddController(Controller controller)
    {
        controller.OnShapeshift += Trigger;
    }

    protected override void RemoveController(Controller controller)
    {
        controller.OnShapeshift -= Trigger;
    }

    public override bool ShouldUse(GameObject target)
    {
        throw new NotImplementedException();
    }

    public void SetShapeshitType(string shapeshiftType)
    {
        this.shapeshiftType = shapeshiftType;

        //switch (shapeshiftType)
        //{
        //    case earthShifshape: boulderAbility = GetComponent<BoulderAbility>(); break;
        //    case windShifshape: windShieldAbility = GetComponent<WindShieldAbility>(); break;

        //    default:
        //        break;
        //}
    }
}
