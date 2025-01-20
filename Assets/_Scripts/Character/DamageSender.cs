using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageSender<T> : LoadData where T : FindNearestTarget
{
    [SerializeField] protected int damage = 1;
    [SerializeField] protected T findNearestTarget;
    protected virtual DamageReceiver<T> Send( T findTarget)
    {
        var target = findTarget.target;
        DamageReceiver<T> damageReceiver = target.GetComponentInChildren<DamageReceiver<T>>();
        if (damageReceiver == null) return null;

        damageReceiver.Receive(this.damage, this);
        return damageReceiver;
    }
}
