using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSender : DamageSenderToTarget<FindNearestHero>
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
        this.enemyStats = transform.parent.GetComponentInChildren<EnemyStats>();
        Debug.Log(transform.name + ": EnemyStats", gameObject);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        damage = enemyStats.damage;
    }
}
