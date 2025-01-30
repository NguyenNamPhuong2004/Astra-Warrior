using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextAnimationEvent : LoadData
{
    [SerializeField] private DamageText damageText;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDamageText();
    }

    private void LoadDamageText()
    {
        if (this.damageText != null) return;
        this.damageText = transform.parent.GetComponentInChildren<DamageText>();
        Debug.Log(transform.name + ": DamageText", gameObject);
    }
    public void DoDespawn()
    {
        damageText.Despawn.DoDespawn();
    }
}
