using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : LoadData
{
    [SerializeField] private AllHeroData allHeroData;
    public int id;
    public int level;
    public int damage;
    public int maxHp;
    public int armor;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadHeroData();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        ResetHeroStats();
    }

    private void ResetHeroStats()
    {
        level = DataPlayer.GetLevelHero(id);
        damage = allHeroData.heroData[id].heroLevel[level].damage;
        maxHp = allHeroData.heroData[id].heroLevel[level].maxHp;
        armor = allHeroData.heroData[id].heroLevel[level].armor;
    }
    public void SetID(int id)
    {
        this.id = id;
    }
    protected virtual void LoadHeroData()
    {
        if (this.allHeroData != null) return;
        this.allHeroData = Resources.Load<AllHeroData>("Prefabs/Hero Data");
        Debug.Log(transform.name + ": allHeroData ", gameObject);
    }
}
