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
    private const string forwardAttackClipName = "Attack Forward";
    private const string backwardAttackClipName = "Attack Backward";
    private const string leftAttackClipName = "Attack Left";
    private const string rightAttackClipName = "Attack Right";

    private Transform projectileCreatPos;

    [SerializeField] private Transform forwardProjectileCreatPos;
    [SerializeField] private Transform backwardProjectileCreatPos;
    [SerializeField] private Transform leftProjectileCreatPos;
    [SerializeField] private Transform rightProjectileCreatPos;

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
        animator.SetBool("isShooting", true);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName(forwardAttackClipName) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            print("For");
            projectileCreatPos = forwardProjectileCreatPos;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName(backwardAttackClipName) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            print("back");
            projectileCreatPos = backwardProjectileCreatPos;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName(leftAttackClipName) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            print("left");
            projectileCreatPos = leftProjectileCreatPos;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName(rightAttackClipName) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            print("right");
            projectileCreatPos = rightProjectileCreatPos;
        }
        else
        {
            print("none");
            projectileCreatPos = forwardProjectileCreatPos;
        }
    }
    public void ShootAfterAnimation()//this function will be called from the attack animation clip (animation event)
    {
        print("Shoot");
        projectileLauncher.Shoot(projectileCreatPos);
        animator.SetBool("isShooting", false);
    }
}
