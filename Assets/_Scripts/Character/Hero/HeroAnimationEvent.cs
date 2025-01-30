using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimationEvent : LoadData
{
    [SerializeField] private HeroAttack heroAttack;
    [SerializeField] private HeroDamageSender heroDamageSender;
    [SerializeField] private HeroDamageReceiver heroDamageReceiver;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadHeroAttack();
        LoadHeroDamageReceiver();
        LoadHeroDamageSender();
    }

    private void LoadHeroAttack()
    {
        if (this.heroAttack != null) return;
        this.heroAttack = GetComponentInChildren<HeroAttack>();
        Debug.Log(transform.name + ": HeroAttack", gameObject);
    }

    private void LoadHeroDamageReceiver()
    {
        if (this.heroDamageReceiver != null) return;
        this.heroDamageReceiver = GetComponentInChildren<HeroDamageReceiver>();
        Debug.Log(transform.name + ": HeroDamageReceiver", gameObject);
    }  
    private void LoadHeroDamageSender()
    {
        if (this.heroDamageSender != null) return;
        this.heroDamageSender = GetComponentInChildren<HeroDamageSender>();
        Debug.Log(transform.name + ": HeroDamageSender", gameObject);
    }

    public void TakeDamage()
    {
        heroAttack.TakeDamage();
        heroDamageSender.Send(GetComponentInChildren<FindNearestEnemy>());
    }
    public void DoDespawn()
    {
        heroDamageReceiver.DoDespawn();
    }
}
