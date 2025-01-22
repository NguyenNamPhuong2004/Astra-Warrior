using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDamageReceiver : DamageReceiver<FindNearestHero>
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
        maxHP = heroStats.maxHp;
        armor = heroStats.armor;
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
