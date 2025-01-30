using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiverToTarget<FindNearestEnemy>
{
    [SerializeField] private EnemyStats enemyStats;
    [SerializeField] private Animator animator;
    [SerializeField] private CapsuleCollider2D capsuleCollider;
    [SerializeField] private Rigidbody2D rigid2D;
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
        LoadRigidbody2D();
    }

    private void LoadEnemyStats()
    {
        if (this.enemyStats != null) return;
        this.enemyStats = transform.parent.GetComponentInChildren<EnemyStats>();
        Debug.Log(transform.name + ": EnemyStats", gameObject);
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
    private void LoadEnemy()
    {
        if (this.enemy != null) return;
        this.enemy = transform.parent.GetComponent<Enemy>();
        Debug.Log(transform.name + ": LoadEnemy", gameObject);
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
        maxHP = enemyStats.maxHp;
        Armor = enemyStats.armor;
        currentHP = MaxHP;
    }
    protected override void OnDead()
    {
        damageTextSpawning.Spawning(transform.position,"Green",realDamage);
        animator.SetTrigger("Dead");
        this.capsuleCollider.enabled = false;
        this.rigid2D.bodyType = RigidbodyType2D.Kinematic;
    }
    public void DoDespawn()
    {
        enemy.Despawn.DoDespawn();
    }

    protected override void OnHurt()
    {
        damageTextSpawning.Spawning(transform.position, "Green",realDamage);
    }
    protected override void Reborn()
    {
        base.Reborn();
        this.capsuleCollider.enabled = true;
        this.rigid2D.bodyType = RigidbodyType2D.Dynamic;
    }
}
