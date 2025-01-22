using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDamageSender : DamageSender<FindNearestEnemy>
{
    [SerializeField] private HeroStats heroStats;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadHeroStats();
    }

    private void LoadHeroStats()
    {
        if (this.heroStats != null) return;
        this.heroStats = GetComponent<HeroStats>();
        Debug.Log(transform.name + ": HeroStats", gameObject);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        damage = heroStats.damage;
    }
}
