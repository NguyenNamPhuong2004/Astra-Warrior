using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMoving : LoadData
{
    [SerializeField] private HeroStats heroStats;
    [SerializeField] private FindNearestEnemy findNearestEnemy;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadHeroStats();
        LoadFindNearestEnemy();
    }

    private void LoadHeroStats()
    {
        if (this.heroStats != null) return;
        this.heroStats = GetComponentInChildren<HeroStats>();
        Debug.Log(transform.name + ": HeroStats", gameObject);
    }
    private void LoadFindNearestEnemy()
    {
        if (this.findNearestEnemy != null) return;
        this.findNearestEnemy = GetComponentInChildren<FindNearestEnemy>();
        Debug.Log(transform.name + ": FindNearestEnemy", gameObject);
    }
    private void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        if (findNearestEnemy.target != null) return;
        transform.Translate(heroStats.speed * Time.deltaTime, 0, 0);
    }
}
