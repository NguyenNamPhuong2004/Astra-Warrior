using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageRecelver : DamageReceiver<FindNearestEnemy>
{
    [SerializeField] private EnemyStats enemyStats;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyStats();
    }

    private void LoadEnemyStats()
    {
        if (this.enemyStats != null) return;
        this.enemyStats = GetComponent<EnemyStats>();
        Debug.Log(transform.name + ": EnemyStats", gameObject);
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
        throw new System.NotImplementedException();
    }

    protected override void OnHurt()
    {
        throw new System.NotImplementedException();
    }
}
