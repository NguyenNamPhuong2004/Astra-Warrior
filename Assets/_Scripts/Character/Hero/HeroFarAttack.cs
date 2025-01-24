using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFarAttack : HeroAttack
{
    [SerializeField] protected ArrowSpawning arrowSpawning;

    protected virtual void LoadArrowSpawning()
    {
        if (this.arrowSpawning != null) return;
        this.arrowSpawning = GameObject.FindObjectOfType<ArrowSpawning>();
        Debug.Log(transform.name + ": LoadArrowSpawning", gameObject);
    }
    protected override void TakeDamage()
    {
        base.TakeDamage();
        SoundManager.Ins.ArrowAttack();
        arrowSpawning.Spawning(transform.GetChild(0).position);
    }
}
