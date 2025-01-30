using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDamageReceiver : DamageReceiverToTarget<FindNearestHero>
{
    [SerializeField] private HeroStats heroStats;
    [SerializeField] private Animator animator;
    [SerializeField] private CapsuleCollider2D capsuleCollider;
    [SerializeField] private Rigidbody2D rigid2D;
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
        LoadRigidbody2D();
    }

    private void LoadHeroStats()
    {
        if (this.heroStats != null) return;
        this.heroStats = transform.parent.GetComponentInChildren<HeroStats>();
        Debug.Log(transform.name + ": HeroStats", gameObject);
    }
    private void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.parent.GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }
    private void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = transform.parent.GetComponent<CapsuleCollider2D>();
        Debug.Log(transform.name + ": LoadCapsuleCollider", gameObject);
    } 
    private void LoadHero()
    {
        if (this.hero != null) return;
        this.hero = transform.parent.GetComponent<Hero>();
        Debug.Log(transform.name + ": LoadHero", gameObject);
    }
    private void LoadDamageTextSpawning()
    {
        if (this.damageTextSpawning != null) return;
        this.damageTextSpawning = GameObject.FindObjectOfType<DamageTextSpawning>();
        Debug.Log(transform.name + ": LoadDamageTextSpawning", gameObject);
    } 
    private void LoadRigidbody2D()
    {
        if (this.rigid2D != null) return;
        this.rigid2D = transform.parent.GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadRigidbody2D", gameObject);
    }
    
    protected override void ResetValue()
    {
        base.ResetValue();
        maxHP = heroStats.maxHp;
        armor = heroStats.armor;
        currentHP = MaxHP;
    }
    protected override void OnDead()
    {
        damageTextSpawning.Spawning(transform.position, "Red",realDamage);
        animator.SetTrigger("Dead");
        this.capsuleCollider.enabled = false;
        this.rigid2D.bodyType = RigidbodyType2D.Kinematic;

    }
    public void DoDespawn()
    {
        hero.Despawn.DoDespawn();
    }

    protected override void OnHurt()
    {
        damageTextSpawning.Spawning(transform.position, "Red",realDamage);
    }
    protected override void Reborn()
    {
        base.Reborn();
        this.capsuleCollider.enabled = true;
        this.rigid2D.bodyType = RigidbodyType2D.Dynamic;
    }
}
