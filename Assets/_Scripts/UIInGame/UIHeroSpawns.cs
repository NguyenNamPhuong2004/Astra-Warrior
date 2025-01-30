using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHeroSpawns : LoadData
{
    [SerializeField] private UIHeroSpawn[] heroSpawn;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadUIHeroSpawn();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        SetID();
    }
    private void LoadUIHeroSpawn()
    {
        if (this.heroSpawn == null && this.heroSpawn.Length > 0) return;
        this.heroSpawn = GetComponentsInChildren<UIHeroSpawn>();
        Debug.Log(transform.name + ": LoadUIHeroSpawn ", gameObject);
    }
    private void Start()
    {
        SetHeroBtn();
    }
    private void SetID()
    {
        if (heroSpawn == null || heroSpawn.Length == 0) return;
        for (int i = 0; i < heroSpawn.Length; i++)
        {
            heroSpawn[i].SetID(i);
            heroSpawn[i].gameObject.SetActive(false);
        }
    }
    private void SetHeroBtn()
    {
        foreach (int heroID in DataPlayer.GetHeroList())
            foreach (var heroBtn in heroSpawn)
            {
                if (heroID == heroBtn.id)
                    heroBtn.gameObject.SetActive(true);
            }
    }

}
