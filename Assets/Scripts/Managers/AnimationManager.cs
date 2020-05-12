using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AnimationDirection
{
    Forward = 0,
    Backward = 1,
    Left = 2,
    Right = 3
}
public class AnimationManager : MonoBehaviour
{
    private Transform projectileCreatPos;
    private Animator animator;
    private ProjectileLauncher projectileLauncher;

    private void Start()
    {
        animator = GetComponent<Animator>();
        projectileLauncher = GetComponent<ProjectileLauncher>();
    }

    public void StartShootingAnimation()
    {
        print("StartShootingAnimation");
        animator.SetBool("isShooting", true);
    }
    public void ShootAfterAnimation()//this function will be called from the attack animation clip (animation event)
    {
        print("Shoot");
        projectileLauncher.Shoot();
        animator.SetBool("isShooting", false);
    }
}
