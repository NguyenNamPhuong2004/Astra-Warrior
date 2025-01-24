using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : LoadData
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

    protected virtual void Move()
    {
        transform.Translate(-enemyStats.speed * Time.deltaTime, 0, 0);
    }
}
