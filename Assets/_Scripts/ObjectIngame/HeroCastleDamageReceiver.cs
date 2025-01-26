using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCastleDamageReceiver : DamageReceiver<FindNearestHero>
{
    protected override void OnDead()
    {
        GameManager.Ins.Defeat();
        Destroy(transform.parent);
    }

    protected override void OnHurt()
    {
        throw new System.NotImplementedException();
    }
}
