using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNearestHero : FindNearestTarget
{
    protected override void ResetValue()
    {
        base.ResetValue();
        targetDectionRadius = 1;
        targetDectionLayer = LayerMask.GetMask("Hero");
        targetCastleDectionLayer = LayerMask.GetMask("HeroCastle");
    }
}
