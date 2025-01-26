using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCastleStats : LoadData
{
    [SerializeField] private ShopCastleData heroCastleData;
    [SerializeField] private int level;
    public int maxHP;
    public int curHP;
    public int armor;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCastleData();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        ResetCastleStats();
    }

    private void ResetCastleStats()
    {
        level = DataPlayer.GetLevelCastle();
        maxHP = heroCastleData.shopCastle.castleLevel[level].maxHp;
        armor = heroCastleData.shopCastle.castleLevel[level].armor;
        curHP = maxHP;
    }
    private void LoadCastleData()
    {
        if (this.heroCastleData != null) return;
        this.heroCastleData = Resources.Load<ShopCastleData>("Prefabs/Castle Data");
        Debug.Log(transform.name + ": CastleData ", gameObject);
    }
}
