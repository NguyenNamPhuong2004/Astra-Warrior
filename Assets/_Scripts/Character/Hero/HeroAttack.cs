using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : LoadData
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected FindNearestEnemy findNearestEnemy;
    // [SerializeField] protected HeroDamageSender heroDamageSender;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAnimator();
        LoadFindNearestEnemy();
    }
    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": Animator", gameObject);
    }
    protected virtual void LoadFindNearestEnemy()
    {
        if (this.findNearestEnemy != null) return;
        this.findNearestEnemy = GetComponent<FindNearestEnemy>();
        Debug.Log(transform.name + ": FindNearestEnemy", gameObject);
    }
    //protected virtual void LoadHeroDamageSender()
    //{
    //    if (this.heroDamageSender != null) return;
    //    this.heroDamageSender = GetComponentInChildren<HeroDamageSender>();
    //    Debug.Log(transform.name + ": HeroDamageSender", gameObject);
    //}
    protected virtual void Attack()
    {
        if (findNearestEnemy.target == null) return;
        animator.SetBool("Attack", true);
        //if (speed == 0) speed = 5;
        //Speed = speed;
        //speed = 0;
    }
    protected virtual void TakeDamage()
    {
        if (findNearestEnemy.target == null)
        {
            animator.SetBool("Attack", false);
            return;
        }
    }
}
