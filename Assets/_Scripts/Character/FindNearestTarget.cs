using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FindNearestTarget : LoadData
{
    public GameObject target;
    [SerializeField] protected float targetDectionRadius;
    [SerializeField] protected LayerMask targetDectionLayer;
    [SerializeField] protected LayerMask targetCastleDectionLayer;

    protected virtual void FixedUpdate()
    {
        DetectEnemy();
    }
    protected virtual void DetectEnemy()
    {
        var targetFindeds = Physics2D.OverlapCircleAll(transform.position, targetDectionRadius, targetDectionLayer);
        var targetCastleFindeds = Physics2D.OverlapCircleAll(transform.position, targetDectionRadius, targetCastleDectionLayer);
        var finalTarget = NearestTarget(targetFindeds);
        var finalTargetCastle = NearestTarget(targetCastleFindeds);
        if (finalTarget == null && finalTargetCastle == null) return;
        if (finalTarget != null) target = finalTarget;
        else target = finalTargetCastle;
    }
    protected virtual GameObject NearestTarget(Collider2D[] targetFindeds)
    {
        float minDistance = 0;
        GameObject finalTarget = null;
        if (targetFindeds == null || targetFindeds.Length <= 0) return null;
        for (int i = 0; i < targetFindeds.Length; i++)
        {
            var enemyFinded = targetFindeds[i];
            if (enemyFinded == null) continue;
            if (finalTarget == null)
            {
                minDistance = Vector2.Distance(transform.position, enemyFinded.transform.position);
            }
            else
            {
                float distanceTemp = Vector2.Distance(transform.position, enemyFinded.transform.position);
                if (distanceTemp > minDistance) continue;
                minDistance = distanceTemp;
            }
            finalTarget = enemyFinded.gameObject;
        }
        return finalTarget;
    }
}

