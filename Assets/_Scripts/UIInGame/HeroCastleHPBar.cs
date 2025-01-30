using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroCastleHPBar : LoadData
{
    [SerializeField] private HeroCastleDamageReceiver heroCastleDamageReceiver;
    [SerializeField] private Text hpText;
    [SerializeField] private Image hpBar;

    private void Start()
    {
        heroCastleDamageReceiver.updateHPBar.AddListener(UpdateHPBar);
        UpdateHPBar();
    }

    private void UpdateHPBar()
    {
        hpText.text = heroCastleDamageReceiver.CurrentHP.ToString() + "/" + heroCastleDamageReceiver.MaxHP.ToString();
        hpBar.fillAmount = (float)heroCastleDamageReceiver.CurrentHP / (float)heroCastleDamageReceiver.MaxHP;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadHeroCastleDamageReceiver();
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

    private void LoadHeroCastleDamageReceiver()
    {
        if (this.heroCastleDamageReceiver != null) return;
        this.heroCastleDamageReceiver = transform.parent.GetComponentInChildren<HeroCastleDamageReceiver>();
        Debug.Log(transform.name + ": LoadHeroCastleDamageReceiver ", gameObject);
    }
}
