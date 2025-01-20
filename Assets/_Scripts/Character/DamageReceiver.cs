using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver<T>: LoadData where T : FindNearestTarget
{
    [SerializeField] protected int currentHP = 10;
    [SerializeField] protected int maxHP = 10;
    [SerializeField] protected int armor = 10;
    [SerializeField] protected bool isDead = false;

    protected abstract void OnDead();
    protected abstract void OnHurt();

    protected virtual void OnEnable()
    {
        this.Reborn();
    }

    public virtual void Receive(int damage, DamageSender<T> damageSender)
    {
        int realDamage = Mathf.CeilToInt(UnityEngine.Random.Range(damage / (1 + armor / 100f) - 2, damage / (1 + armor / 100f) + 3));
        this.currentHP -= realDamage;
        if (this.currentHP < 0) this.currentHP = 0;

        if (this.IsDead()) this.OnDead();
        else this.OnHurt();
    }

    public virtual bool IsDead()
    {
        return this.isDead = this.currentHP <= 0;
    }

    protected virtual void Reborn()
    {
        this.currentHP = this.maxHP;
    }
}
