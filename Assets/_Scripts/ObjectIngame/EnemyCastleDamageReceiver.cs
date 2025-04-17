using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCastleDamageReceiver : DamageReceiverToTarget<FindNearestEnemy>
{
    public UnityEvent updateHPBar;
    [SerializeField] private EnemyCastleStats enemyCastleStats;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyCastleStats();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        maxHP = enemyCastleStats.maxHP;
        armor = enemyCastleStats.armor;
        currentHP = maxHP;
    }
    private void LoadEnemyCastleStats()
    {
        if (this.enemyCastleStats != null) return;
        this.enemyCastleStats = transform.parent.GetComponentInChildren<EnemyCastleStats>();
        Debug.Log(transform.name + ": EnemyCastleStats", gameObject);
    }
    protected override void OnDead()
    {
        GameManager.Ins.Victory();
        Destroy(transform.parent.gameObject);
    }
    public virtual bool IsHurt()
    {
        return this.CurrentHP < this.MaxHP;
    }
    public override void Receive(int damage, DamageSenderToTarget<FindNearestEnemy> damageSender)
    {
        base.Receive(damage, damageSender);
        updateHPBar.Invoke();
    }

    protected override void OnHurt()
    {
        throw new System.NotImplementedException();
    }
}
