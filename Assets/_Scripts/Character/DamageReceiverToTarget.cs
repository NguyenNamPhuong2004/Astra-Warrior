using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiverToTarget<T>: LoadData where T : FindNearestTarget
{
    [SerializeField] protected int currentHP = 10;
    [SerializeField] protected int maxHP = 10;
    [SerializeField] protected int armor = 10;
    [SerializeField] protected int realDamage = 10;
    [SerializeField] protected bool isDead = false;

    public int CurrentHP { get => currentHP; private set => currentHP = value; }
    public int MaxHP { get => maxHP; private set => maxHP = value; }
    public int Armor { get => armor; set => armor = value; }

    protected abstract void OnDead();
    protected abstract void OnHurt();

    protected virtual void OnEnable()
    {
        this.Reborn();
    }

    public virtual void Receive(int damage, DamageSenderToTarget<T> damageSender)
    {
        realDamage = Mathf.CeilToInt(UnityEngine.Random.Range(damage / (1 + armor / 100f) - 2, damage / (1 + armor / 100f) + 3));
        this.CurrentHP -= realDamage;
        if (this.CurrentHP < 0) this.CurrentHP = 0;

        if (this.IsDead()) this.OnDead();
        else this.OnHurt();
    }

    public virtual bool IsDead()
    {
        return this.isDead = this.CurrentHP <= 0;
    }

    protected virtual void Reborn()
    {
        this.CurrentHP = this.MaxHP;
    }
}
