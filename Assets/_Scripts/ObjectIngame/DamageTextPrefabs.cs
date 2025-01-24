using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextPrefabs : PoolPrefabs<DamageText>
{
    protected override void LoadPrefabs()
    {
        if (this.prefabs.Length > 0) return;
        this.prefabs = Resources.LoadAll<DamageText>("Prefabs/DamageText");
        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }
}
