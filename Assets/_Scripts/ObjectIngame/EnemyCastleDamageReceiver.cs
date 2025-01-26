using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCastleDamageReceiver : DamageReceiver<FindNearestEnemy>
{
    protected override void OnDead()
    {
        GameManager.Ins.Victory();
        Destroy(transform.parent);
    }
    public virtual bool IsHurt()
    {
        return this.currentHP < this.maxHP;
    }

    protected override void OnHurt()
    {
        throw new System.NotImplementedException();
    }
}
