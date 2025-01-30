using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyCastleHPBar : LoadData
{
    [SerializeField] private EnemyCastleDamageReceiver enemyCastleDamageReceiver;
    [SerializeField] private Text hpText;
    [SerializeField] private Image hpBar;

    private void Start()
    {
        UpdateHPBar();
        enemyCastleDamageReceiver.updateHPBar.AddListener(UpdateHPBar);
    }

    private void UpdateHPBar()
    {
        hpText.text = enemyCastleDamageReceiver.CurrentHP.ToString() + "/" + enemyCastleDamageReceiver.MaxHP.ToString();
        hpBar.fillAmount = (float)enemyCastleDamageReceiver.CurrentHP / (float)enemyCastleDamageReceiver.MaxHP;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyCastleDamageReceiver();
        LoadHPText();
        LoadHPBar();
    }

    private void LoadHPBar()
    {
        if (this.hpBar != null) return;
        this.hpBar = transform.GetChild(1).GetComponent<Image>();
        Debug.Log(transform.name + ": LoadHPBar ", gameObject);
    }

    private void LoadHPText()
    {
        if (this.hpText != null) return;
        this.hpText = GetComponentInChildren<Text>();
        Debug.Log(transform.name + ": LoadHPText ", gameObject);
    }

    private void LoadEnemyCastleDamageReceiver()
    {
        if (this.enemyCastleDamageReceiver != null) return;
        this.enemyCastleDamageReceiver = transform.parent.GetComponentInChildren<EnemyCastleDamageReceiver>();
        Debug.Log(transform.name + ": LoadEnemyCastleDamageReceiver ", gameObject);
    }

}
