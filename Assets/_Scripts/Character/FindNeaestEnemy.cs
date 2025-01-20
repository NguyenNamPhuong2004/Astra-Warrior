using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNearestEnemy : FindNearestTarget
{
   protected override void ResetValue()
   {
        base.ResetValue();
        targetDectionRadius = 1;
        targetDectionLayer = LayerMask.GetMask("Enemy");
        targetCastleDectionLayer = LayerMask.GetMask("EnemyCastle");
   }
}
