using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeroCastleDamageReceiver : DamageReceiverToTarget<FindNearestHero>
{
    public UnityEvent updateHPBar;
    [SerializeField] private HeroCastleStats heroCastleStats;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadHeroCastleStats();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        maxHP = heroCastleStats.maxHP;
        armor = heroCastleStats.armor;
        currentHP = maxHP;
    }
    private void LoadHeroCastleStats()
    {
        if (this.heroCastleStats != null) return;
        this.heroCastleStats = transform.parent.GetComponentInChildren<HeroCastleStats>();
        Debug.Log(transform.name + ": HeroCastleStats", gameObject);
    }
    protected override void OnDead()
    {
        GameManager.Ins.Defeat();
        Destroy(transform.parent.gameObject);
    }
    public override void Receive(int damage, DamageSenderToTarget<FindNearestHero> damageSender)
    {
        base.Receive(damage, damageSender);
        updateHPBar.Invoke();
    }
    protected override void OnHurt()
    {
        
    }
}
