using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : LoadData
{
    [SerializeField] private EnemyStats enemyStats;
    [SerializeField] private FindNearestHero findNearestHero;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyStats();
        LoadFindNearestHero();
    }

    private void LoadEnemyStats()
    {
        if (this.enemyStats != null) return;
        this.enemyStats = GetComponentInChildren<EnemyStats>();
        Debug.Log(transform.name + ": EnemyStats", gameObject);
    }
    private void LoadFindNearestHero()
    {
        if (this.findNearestHero != null) return;
        this.findNearestHero = GetComponentInChildren<FindNearestHero>();
        Debug.Log(transform.name + ": FindNearestHero", gameObject);
    }
    private void Update()
    {
        Move();
    }
    protected virtual void Move()
    {
        if (findNearestHero.target != null) return;
        transform.Translate(-enemyStats.speed * Time.deltaTime, 0, 0);
    }
}
