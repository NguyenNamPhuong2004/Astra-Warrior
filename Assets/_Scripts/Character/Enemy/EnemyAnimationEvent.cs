using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvent : LoadData
{
    [SerializeField] private EnemyAttack enemyAttack;
    [SerializeField] private EnemyDamageSender enemyDamageSender;
    [SerializeField] private EnemyDamageReceiver enemyDamageReceiver;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyAttack();
        LoadEnemyDamageReceiver();
        LoadEnemyDamageSender();
    }

    private void LoadEnemyAttack()
    {
        if (this.enemyAttack != null) return;
        this.enemyAttack = GetComponentInChildren<EnemyAttack>();
        Debug.Log(transform.name + ": EnemyAttack", gameObject);
    }

    private void LoadEnemyDamageReceiver()
    {
        if (this.enemyDamageReceiver != null) return;
        this.enemyDamageReceiver = GetComponentInChildren<EnemyDamageReceiver>();
        Debug.Log(transform.name + ": EnemyDamageReceiver", gameObject);
    }
    private void LoadEnemyDamageSender()
    {
        if (this.enemyDamageSender != null) return;
        this.enemyDamageSender = GetComponentInChildren<EnemyDamageSender>();
        Debug.Log(transform.name + ": EnemyDamageSender", gameObject);
    }

    public void TakeDamage()
    {
        enemyAttack.TakeDamage();
        enemyDamageSender.Send(GetComponentInChildren<FindNearestHero>());
    }
    public void DoDespawn()
    {
        enemyDamageReceiver.DoDespawn();
    }
}
