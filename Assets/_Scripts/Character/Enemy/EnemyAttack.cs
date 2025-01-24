using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : LoadData
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected FindNearestHero findNearestHero;
    // [SerializeField] protected HeroDamageSender heroDamageSender;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAnimator();
        LoadFindNearestHero();
    }
    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": Animator", gameObject);
    }
    protected virtual void LoadFindNearestHero()
    {
        if (this.findNearestHero != null) return;
        this.findNearestHero = GetComponent<FindNearestHero>();
        Debug.Log(transform.name + ": FindNearestHero", gameObject);
    }
    //protected virtual void LoadHeroDamageSender()
    //{
    //    if (this.heroDamageSender != null) return;
    //    this.heroDamageSender = GetComponentInChildren<HeroDamageSender>();
    //    Debug.Log(transform.name + ": HeroDamageSender", gameObject);
    //}
    protected virtual void Attack()
    {
        if (findNearestHero.target == null) return;
        animator.SetBool("Attack", true);
        //if (speed == 0) speed = 5;
        //Speed = speed;
        //speed = 0;
    }
    protected virtual void TakeDamage()
    {
        if (findNearestHero.target == null)
        {
            animator.SetBool("Attack", false);
            return;
        }
        SoundManager.Ins.SwordAttack();
    }
}
