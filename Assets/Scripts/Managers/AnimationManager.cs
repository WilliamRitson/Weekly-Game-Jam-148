using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AnimationDirection
{
    Forward = 0,
    Backward = 1,
    Right = 2,
    Left = 3
}
public class AnimationManager : MonoBehaviour
{
    private Animator animator;
    private ProjectileLauncher projectileLauncher;

    //private void Awake()
    //{
        
    //}

    private void Start()
    {
        animator = GetComponent<Animator>();
        projectileLauncher = GetComponent<ProjectileLauncher>();
    }

    public void StartShootingAnimation()
    {
        print("StartShootingAnimation");
        animator.Play("Wizard Spell Cast", 0);
    }
    public void ShootAfterAnimation()//this function will be called from the attack animation clip (animation event)
    {
        print("Shoot");
        projectileLauncher.Shoot();
    }

    //public void StopShootingAnimation()
    //{
    //    print("false");
    //    animator.SetBool("isShooting", false);
    //}
}
