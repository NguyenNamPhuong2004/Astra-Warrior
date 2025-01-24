using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeroPrefabs : PoolPrefabs<Hero>
{
    protected override void LoadPrefabs()
    {
        if (this.prefabs.Length > 0) return;
        this.prefabs = Resources.LoadAll<Hero>("Prefabs/Hero");
        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }
}
