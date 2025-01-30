using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageSenderToTarget<T> : LoadData where T : FindNearestTarget
{
    [SerializeField] protected int damage = 1;
    [SerializeField] protected T findNearestTarget;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadFindNearestTarget();
    }

    private void LoadFindNearestTarget()
    {
        if (this.findNearestTarget != null) return;
        this.findNearestTarget = transform.parent.GetComponentInChildren<T>();
        Debug.Log(transform.name + ": LoadFindNearestTarget", gameObject);
    }

    public virtual DamageReceiverToTarget<T> Send(T findTarget)
    {
        var target = findTarget.target;
        DamageReceiverToTarget<T> damageReceiver = target.GetComponentInChildren<DamageReceiverToTarget<T>>();
        if (damageReceiver == null) return null;

        damageReceiver.Receive(this.damage, this);
        return damageReceiver;
    }
    public virtual DamageReceiverToTarget<T> Send(Collider2D collider2D)
    {
        DamageReceiverToTarget<T> damageReceiver = collider2D.GetComponentInChildren<DamageReceiverToTarget<T>>();
        if (damageReceiver == null) return null;

        damageReceiver.Receive(this.damage, this);
        return damageReceiver;
    }
}
