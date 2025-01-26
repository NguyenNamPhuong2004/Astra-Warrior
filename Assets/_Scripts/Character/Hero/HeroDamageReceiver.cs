using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDamageReceiver : DamageReceiver<FindNearestHero>
{
    [SerializeField] private HeroStats heroStats;
    [SerializeField] private Animator animator;
    [SerializeField] private CapsuleCollider capsuleCollider;
    [SerializeField] private Hero hero;
    [SerializeField] private DamageTextSpawning damageTextSpawning;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadHeroStats();
        LoadAnimator();
        LoadCapsuleCollider();
        LoadHero();
        LoadDamageTextSpawning();
    }

    private void LoadHeroStats()
    {
        if (this.heroStats != null) return;
        this.heroStats = GetComponent<HeroStats>();
        Debug.Log(transform.name + ": HeroStats", gameObject);
    }
    private void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }
    private void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider>();
        Debug.Log(transform.name + ": LoadCapsuleCollider", gameObject);
    } 
    private void LoadHero()
    {
        if (this.hero != null) return;
        this.hero = GetComponent<Hero>();
        Debug.Log(transform.name + ": LoadHero", gameObject);
    }
    private void LoadDamageTextSpawning()
    {
        if (this.damageTextSpawning != null) return;
        this.damageTextSpawning = GetComponentInChildren<DamageTextSpawning>();
        Debug.Log(transform.name + ": LoadDamageTextSpawning", gameObject);
    }
    
    protected override void ResetValue()
    {
        base.ResetValue();
        maxHP = heroStats.maxHp;
        armor = heroStats.armor;
        currentHP = maxHP;
    }
    protected override void OnDead()
    {
        damageTextSpawning.Spawning(damageTextSpawning.transform.position);
        animator.SetTrigger("Dead");
        this.capsuleCollider.enabled = false;
        Invoke(nameof(this.DoDespawn), 2f);
    }
    private void DoDespawn()
    {
        hero.Despawn.DoDespawn();
    }

    protected override void OnHurt()
    {
        damageTextSpawning.Spawning(damageTextSpawning.transform.position);
    }
    protected override void Reborn()
    {
        base.Reborn();
        this.capsuleCollider.enabled = true;
    }
}
