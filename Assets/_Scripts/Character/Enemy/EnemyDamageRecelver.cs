using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageRecelver : DamageReceiver<FindNearestEnemy>
{
    [SerializeField] private EnemyStats enemyStats;
    [SerializeField] private Animator animator;
    [SerializeField] private CapsuleCollider capsuleCollider;
    [SerializeField] private Enemy enemy;
    [SerializeField] private DamageTextSpawning damageTextSpawning;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyStats();
        LoadAnimator();
        LoadCapsuleCollider();
        LoadEnemy();
        LoadDamageTextSpawning();
    }

    private void LoadEnemyStats()
    {
        if (this.enemyStats != null) return;
        this.enemyStats = GetComponent<EnemyStats>();
        Debug.Log(transform.name + ": EnemyStats", gameObject);
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
    private void LoadEnemy()
    {
        if (this.enemy != null) return;
        this.enemy = GetComponent<Enemy>();
        Debug.Log(transform.name + ": LoadEnemy", gameObject);
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
        maxHP = enemyStats.maxHp;
        armor = enemyStats.armor;
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
        enemy.Despawn.DoDespawn();
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
