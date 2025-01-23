using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMoving : LoadData
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

    protected virtual void Move()
    {
        transform.Translate(heroStats.speed * Time.deltaTime, 0, 0);
    }
}
