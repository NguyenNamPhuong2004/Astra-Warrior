using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRainParticle : DamageSenderToTarget<FindNearestEnemy>
{
    [SerializeField] protected ArrowRainSkill arrowRain;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadArrowRainSkill();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        damage = arrowRain.damage;
    }
    private void LoadArrowRainSkill()
    {
        if (this.arrowRain != null) return;
        this.arrowRain = GetComponent<ArrowRainSkill>();
        Debug.Log(transform.name + ": LoadArrowRain", gameObject);
    }
    private void OnParticleCollision(GameObject other)
    {
        this.Send(other.GetComponent<Collider2D>());
    }
   
}
