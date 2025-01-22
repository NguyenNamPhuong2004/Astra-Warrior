using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageRecelver : DamageReceiver<FindNearestEnemy>
{
    protected override void OnDead()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnHurt()
    {
        throw new System.NotImplementedException();
    }
}
