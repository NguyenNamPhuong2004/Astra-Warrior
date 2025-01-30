using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFarAttack : HeroAttack
{
    [SerializeField] protected ArrowSpawning arrowSpawning;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadArrowSpawning();
    }
    protected virtual void LoadArrowSpawning()
    {
        if (this.arrowSpawning != null) return;
        this.arrowSpawning = transform.parent.GetComponentInChildren<ArrowSpawning>();
        Debug.Log(transform.name + ": LoadArrowSpawning", gameObject);
    }
    public override void TakeDamage()
    {
        base.TakeDamage();
        SoundManager.Ins.ArrowAttack();
        arrowSpawning.Spawning(transform.GetChild(0).position);
    }
}
