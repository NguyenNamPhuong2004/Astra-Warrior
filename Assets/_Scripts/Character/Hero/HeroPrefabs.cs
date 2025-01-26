using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeroPrefabs : PoolPrefabs<Hero>
{
    private void Start()
    {
        SetID();
    }
    protected override void LoadPrefabs()
    {
        if (this.prefabs.Length > 0) return;
        this.prefabs = Resources.LoadAll<Hero>("Prefabs/Hero");
        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }
    private void SetID()
    {
        if (prefabs == null || prefabs.Length == 0) return;
        for (int i = 0; i < prefabs.Length; i++)
        {
            prefabs[i].GetComponent<HeroStats>().SetID(i);
        }
    }
}
