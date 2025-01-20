using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroCtrl : LoadData
{
    [SerializeField] protected FindNearestEnemy findNearestEnemy;
    public FindNearestEnemy FindNearestEnemy => findNearestEnemy;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadFindNearestEnemy();
    }
    protected virtual void LoadFindNearestEnemy()
    {
        if (this.findNearestEnemy != null) return;
        this.findNearestEnemy = GetComponentInChildren<FindNearestEnemy>();
        Debug.Log(transform.name + ": FindNearestEnemy ", gameObject);
    }
}
